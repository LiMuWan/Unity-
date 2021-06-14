using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class vortex : MonoBehaviour {
    // (1)关联材质对象带代码，手动拖，调用代码加载
    public Material mat; // 配置输入数据文件;

    float radius_speed = 0.1f; // 2s变换到 1 radis;
    float angle_speed = 0.5f; // 2s --> 2弧度

    float total_time = 3.0f; // 特效持续的时间;
    float run_time = 0.0f; // 当前特效的运行的时间;

    float now_radius = 0.0f; // 现在的波及范围;
    float now_angle = 0.0f; // 现在的波及角度;

	// Use this for initialization
	void Start () {
        for (int j = 0; j < 3; j++) {
            // 执行一次, 10, 20, 40, 80
            Mesh self_mesh = this.GetComponent<MeshFilter>().mesh;

            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            List<Vector3> normals = new List<Vector3>();
            List<Vector2> uv = new List<Vector2>();
            List<Vector4> tangents = new List<Vector4>();


            for (int i = 0; i < self_mesh.triangles.Length / 3; i++)
            {
                Vector3 t0 = self_mesh.vertices[self_mesh.triangles[i * 3 + 0]];
                Vector3 t1 = self_mesh.vertices[self_mesh.triangles[i * 3 + 1]];
                Vector3 t2 = self_mesh.vertices[self_mesh.triangles[i * 3 + 2]];

                Vector3 t3 = Vector3.Lerp(t0, t1, 0.5f);
                Vector3 t4 = Vector3.Lerp(t1, t2, 0.5f);
                Vector3 t5 = Vector3.Lerp(t0, t2, 0.5f);

                int count = vertices.Count;
                vertices.Add(t0); // count + 0
                vertices.Add(t1); // count + 1
                vertices.Add(t2); // count + 2
                vertices.Add(t3); // count + 3
                vertices.Add(t4); // count + 4
                vertices.Add(t5); // count + 5

                triangles.Add(count + 0); triangles.Add(count + 3); triangles.Add(count + 5);
                triangles.Add(count + 3); triangles.Add(count + 1); triangles.Add(count + 4);
                triangles.Add(count + 4); triangles.Add(count + 2); triangles.Add(count + 5);
                triangles.Add(count + 3); triangles.Add(count + 4); triangles.Add(count + 5);

                Vector3 n0 = self_mesh.normals[self_mesh.triangles[i * 3 + 0]];
                Vector3 n1 = self_mesh.normals[self_mesh.triangles[i * 3 + 1]];
                Vector3 n2 = self_mesh.normals[self_mesh.triangles[i * 3 + 2]];

                Vector3 n3 = Vector3.Lerp(n0, n1, 0.5f);
                Vector3 n4 = Vector3.Lerp(n1, n2, 0.5f);
                Vector3 n5 = Vector3.Lerp(n0, n2, 0.5f);

                normals.Add(n0); // count + 0
                normals.Add(n1); // count + 1
                normals.Add(n2); // count + 2
                normals.Add(n3); // count + 3
                normals.Add(n4); // count + 4
                normals.Add(n5); // count + 5

                Vector2 uv0 = self_mesh.uv[self_mesh.triangles[i * 3 + 0]];
                Vector2 uv1 = self_mesh.uv[self_mesh.triangles[i * 3 + 1]];
                Vector2 uv2 = self_mesh.uv[self_mesh.triangles[i * 3 + 2]];

                Vector2 uv3 = Vector3.Lerp(uv0, uv1, 0.5f);
                Vector2 uv4 = Vector3.Lerp(uv1, uv2, 0.5f);
                Vector2 uv5 = Vector3.Lerp(uv0, uv2, 0.5f);

                uv.Add(uv0); // count + 0
                uv.Add(uv1); // count + 1
                uv.Add(uv2); // count + 2
                uv.Add(uv3); // count + 3
                uv.Add(uv4); // count + 4
                uv.Add(uv5); // count + 5

                Vector4 tan0 = self_mesh.tangents[self_mesh.triangles[i * 3 + 0]];
                Vector4 tan1 = self_mesh.tangents[self_mesh.triangles[i * 3 + 1]];
                Vector4 tan2 = self_mesh.tangents[self_mesh.triangles[i * 3 + 2]];

                Vector4 tan3 = Vector3.Lerp(tan0, tan1, 0.5f);
                Vector4 tan4 = Vector3.Lerp(tan1, tan2, 0.5f);
                Vector4 tan5 = Vector3.Lerp(tan0, tan2, 0.5f);

                tangents.Add(tan0); // count + 0
                tangents.Add(tan1); // count + 1
                tangents.Add(tan2); // count + 2
                tangents.Add(tan3); // count + 3
                tangents.Add(tan4); // count + 4
                tangents.Add(tan5); // count + 5
            }
            self_mesh.Clear();
            self_mesh.vertices = vertices.ToArray();
            self_mesh.triangles = triangles.ToArray();
            self_mesh.normals = normals.ToArray();
            self_mesh.uv = uv.ToArray();
            self_mesh.tangents = tangents.ToArray();

            self_mesh.RecalculateBounds();
        }
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        this.run_time += dt;

        this.now_radius += (this.radius_speed * dt);
        if (this.now_radius >= 0.5f) {
            this.now_radius = 1.0f;
        }
        this.now_angle += (this.angle_speed * dt);

        this.mat.SetFloat("radius", this.now_radius);
        this.mat.SetFloat("angle", this.now_angle);

        // 特效时间结束了
        if (this.run_time >= this.total_time) {
            // 重新转一次
            this.now_angle = 0;
            this.now_radius = 0;
            this.run_time = 0;
            // end 
        }
	}
}
