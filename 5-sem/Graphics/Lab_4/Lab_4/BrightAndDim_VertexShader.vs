//#version 330 core
//layout (location = 0) in vec3 aPos; // the position variable has attribute position 0


//out vec4 vertexColor;




//void main()
//{


//    gl_Position = (aPos, 1.0)//buff_x*buff_y*buff_z*vec4(aPos, 1.0);

//    vertexColor = vec4(max(0.1, aPos.x), max(0.1, aPos.y), max(0.1, aPos.z), 1f);
//}




#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec2 aTexCoords;

uniform float angle_x;
uniform float angle_y;
uniform float angle_z;

mat4x4 rotationMatrix(vec3 axis, float angle)
{
    axis = normalize(axis);
    float s = sin(angle);
    float c = cos(angle);
    float oc = 1.0 - c;
        
    return mat4x4(oc * axis.x * axis.x + c,           oc * axis.x * axis.y - axis.z * s,  oc * axis.z * axis.x + axis.y * s,  0.0,
                  oc * axis.x * axis.y + axis.z * s,  oc * axis.y * axis.y + c,           oc * axis.y * axis.z - axis.x * s,  0.0,
                  oc * axis.z * axis.x - axis.y * s,  oc * axis.y * axis.z + axis.x * s,  oc * axis.z * axis.z + c,           0.0,
                  0.0,                                0.0,                                0.0,                                1.0);
}


out vec2 TexCoords;
out vec3 outNormal;


uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;


void main()
{
    mat4x4 buff_x = rotationMatrix(vec3(1, 0, 0), angle_x);
    mat4x4 buff_y = rotationMatrix(vec3(0, 1, 0), angle_y);
    mat4x4 buff_z = rotationMatrix(vec3(0, 0, 1), angle_z);

    gl_Position = projection * view * model * vec4(aPos, 1.0f);
    //gl_Position = buff_x*buff_y*buff_z*vec4(aPos, 1.0);

    TexCoords = aTexCoords;
    outNormal=aNormal;
    //gl_Position = vec4(aPos, 1.0);
}