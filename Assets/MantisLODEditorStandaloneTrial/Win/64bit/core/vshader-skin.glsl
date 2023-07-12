#ifdef GL_ES
// Set default precision to medium
precision mediump int;
precision mediump float;
#endif

const int BoneCount = 112;

uniform mat4 u_model_matrix[BoneCount];
uniform mat4 u_normal_matrix[BoneCount];
uniform vec3 u_light_direction;

attribute vec3 a_position;
attribute vec3 a_normal;
attribute vec2 a_texcoord;
attribute vec3 a_barycentric;

attribute vec4 a_bone_weights;
attribute vec4 a_bone_indices;

varying vec2 v_texcoord;
varying float v_light_intensity;
varying vec3 v_barycentric;

void main()
{
    // calculate position
    vec4 pos = vec4(a_position, 1.0);
    vec4 p0 = u_model_matrix[int(a_bone_indices.x)] * pos;
    vec4 p1 = u_model_matrix[int(a_bone_indices.y)] * pos;
    vec4 p2 = u_model_matrix[int(a_bone_indices.z)] * pos;
    vec4 p3 = u_model_matrix[int(a_bone_indices.w)] * pos;
    gl_Position = p0 * a_bone_weights.x + p1 * a_bone_weights.y + p2 * a_bone_weights.z + p3 * a_bone_weights.w;

    // calculate normal
    vec4 norm = vec4(a_normal, 1.0);
    vec4 n0 = u_normal_matrix[int(a_bone_indices.x)] * norm;
    vec4 n1 = u_normal_matrix[int(a_bone_indices.y)] * norm;
    vec4 n2 = u_normal_matrix[int(a_bone_indices.z)] * norm;
    vec4 n3 = u_normal_matrix[int(a_bone_indices.w)] * norm;
    vec4 n = n0 * a_bone_weights.x + n1 * a_bone_weights.y + n2 * a_bone_weights.z + n3 * a_bone_weights.w;

    // calculate light intensity, range of 0.3 ~ 1.0
    v_light_intensity = max(dot(u_light_direction, normalize(n.xyz)), 0.3);

    // Pass texture coordinate to fragment shader
    v_texcoord = a_texcoord;

    // Pass bary centric to fragment shader
    v_barycentric = a_barycentric;
}
