#version 330
#define M_PI 3.1415926535897932384626433832795

in vec3 fColor;
in vec3 fPosition;

out vec4 sColor;
vec3 color;


uniform vec2 offset;
uniform vec2 scaleSpeed;

uniform float cols;
uniform float rows;

uniform vec2 mouse;

uniform float rotationAngle;

uniform vec2 screenSize;

void main(void) {

    float scaling = 1.0f/(scaleSpeed.x +scaleSpeed.y);

    vec2 mouseNormalized = vec2(mouse.x / screenSize.x, mouse.y / screenSize.y);


    float threshold = 0.1f;

    float angularStep = 2* M_PI/rows;

    float phi = ((1f + sqrt(5f)) / 2f);

    vec2 center = fColor.xy - vec2(0.5f,0.5f);

    vec2 effectSize = vec2(length(fColor.xy ) / angularStep, 1.0 / cols);
    vec2 gridSize = vec2(1.0 /rows, 1.0 / cols);
    float scale = 2;

    mat2 rotationMatrix = mat2(cos(rotationAngle), -sin(rotationAngle), 
                            sin(rotationAngle), cos(rotationAngle));
    vec2 rotatedCoords = rotationMatrix * center;

    vec2 scaledCoords = (rotatedCoords  * scaling/scale);

    vec2 gridIndex = floor(scaledCoords / effectSize);
    vec3 color;
    float distToMouse =length((fColor.yx) - mouseNormalized);



    if (int(gridIndex.x) % 2 == int(gridIndex.y) % 2) {
        color = vec3(1.0f, 1.0f, 1.0f);
    } else {
        color = vec3(0.0f, 0.0f, 0.0f);
    }

    if (distToMouse < threshold && gl_FrontFacing) {
        color.x += 0.5f;
        color.y += 0.5f;
        color.z += 0.5f;
    } else {
        color -= vec3(0.5f, 0.5f, 0.5f);
    }
    sColor = vec4(color, 1.0);
}