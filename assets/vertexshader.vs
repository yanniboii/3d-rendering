#version 330

in vec3 vertex;
in vec3 color;
uniform vec2 offset;
uniform float cols;
uniform float time;

out vec3 fColor;
out vec3 fPosition;

void main (void) {

    vec3 displacedVertex = vertex;
    displacedVertex.y += 0.1 * sin(time + vertex.x);
    displacedVertex.x += 0.1 * cos(time + vertex.y);
    displacedVertex.xy += offset;
    gl_Position = vec4(displacedVertex, 1);
    fColor = color;
    fPosition = displacedVertex;
}

