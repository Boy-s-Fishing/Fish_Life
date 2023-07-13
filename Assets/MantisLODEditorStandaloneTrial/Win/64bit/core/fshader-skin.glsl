#ifdef GL_ES
// Set default precision to medium
precision mediump int;
precision mediump float;
#endif

uniform vec4 u_color;
uniform sampler2D u_texture;
uniform float u_highlight;

varying vec2 v_texcoord;
varying float v_light_intensity;
varying vec3 v_barycentric;

void main()
{
    float min_dist = min(min(v_barycentric.x, v_barycentric.y), v_barycentric.z);
    float edgeIntensity = (1.0 - smoothstep(0.0, fwidth(min_dist), min_dist)) * u_highlight;
    // Set diffuse color from texture
    vec4 diffuse = u_color * texture2D(u_texture, v_texcoord) * vec4(vec3(v_light_intensity), 1.0);
    gl_FragColor = edgeIntensity * vec4(0.0, 0.0, 0.0, 1.0) + (1.0 - edgeIntensity) * diffuse;
}
