#pragma once

#include <string>

#ifndef GLRENDERSYSTEM_H
#define GLRENDERSYSTEM_H
#define PI 3.14159265359

namespace Vintall 
{
    namespace GraphCore 
    {
        class GLRenderer
        {
            Vintall::GraphCore::GLShader* gl_shader;
        public:
            void init() 
            {
                /*if (!glfwInit()) {
                    fprintf(stderr, "Ошибка при инициализации GLFW\n");
                }
                glfwWindowHint(GLFW_SAMPLES, 4);
                glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
                glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 0);*/
            }
            void InitShader(const char* vs, const char* fs)
            {
                gl_shader = new Vintall::GraphCore::GLShader(vs, fs);
                fprintf(stdout, vs);
                fprintf(stdout, fs);
            }
            int colorRGB = 1;

            void render(GLFWwindow* window)
            {
                gl_shader->use();
                glClearColor(sin(colorRGB * PI / 180), abs(cos(colorRGB * PI / 180)), abs(sin(colorRGB * PI / 180) + cos(colorRGB * PI / 180)), 1.0f);
                glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
                {
                    colorRGB <= 180 ? colorRGB += 0.1f : colorRGB = 0.0f;
                }
                
                /*glEnable(GL_DEPTH_TEST);
                glMatrixMode(GL_MODELVIEW);
                glPushMatrix();
                double x = glfwGetTime();
                float x_angle = sin(glfwGetTime());
                float y_angle = cos(glfwGetTime());
                float z_angle = 2*sin(glfwGetTime());

                int x_angle_link = glGetUniformLocation(gl_shader->ID, "angle_x");
                int y_angle_link = glGetUniformLocation(gl_shader->ID, "angle_y");
                int z_angle_link = glGetUniformLocation(gl_shader->ID, "angle_z");
                glUniform1f(x_angle_link, x_angle);
                glUniform1f(y_angle_link, y_angle);
                glUniform1f(z_angle_link, z_angle);

                glGenBuffers(1, &Cube::VAO);
                glBindBuffer(GL_ARRAY_BUFFER, Cube::VAO);
                glBufferData(GL_ARRAY_BUFFER, sizeof(Cube::vertices), Cube::vertices, GL_STATIC_DRAW);

                glVertexPointer(3, GL_FLOAT, 0, NULL);
                glBindBuffer(GL_ARRAY_BUFFER, Cube::VAO);

                glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 5 * sizeof(float), (void*)0);
                glEnableVertexAttribArray(0);
                glEnableClientState(GL_VERTEX_ARRAY);
                glDrawArrays(GL_TRIANGLES, 0, (sizeof(Cube::vertices) / sizeof(Cube::vertices[0]) / 5));
                glPopMatrix();
                glDisableClientState(GL_VERTEX_ARRAY);
                
                glEnd();*/

            }
        };
    }
}


#endif