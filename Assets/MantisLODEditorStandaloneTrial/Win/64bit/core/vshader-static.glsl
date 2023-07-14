#ifdef GL_ES
// Set default precision to medium
precision mediump int;
precision mediump float;
#endif

uniform mat4 u_mvp_matrix;
uniform vec3 u_light_direction;

attribute vec3 a_position;
attribute vec3 a_normal;
attribute vec2 a_texcoord;
attribute vec3 a_barycentric;

varying vec2 v_texcoord;
varying float v_light_intensity;
varying vec3 v_barycentric;

void main()
{
    // Calculate vertex position in screen space
    gl_Position = u_mvp_matrix * vec4(a_position, 1.0);

    // calculate light intensity, range of 0.3 ~ 1.0
    v_light_intensity = max(dot(u_light_direction, a_normal), 0.3);

    // Pass texture coordinate to fragment shader
    v_texcoord = a_texcoord;

    // Pass bary centric to fragment shader
    v_barycentric = a_barycentric;
}
