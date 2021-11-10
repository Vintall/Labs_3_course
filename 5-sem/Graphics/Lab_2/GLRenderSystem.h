/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

 /*
  * File:   GLRenderSystem.h
  * Author: KnightDanila
  *
  * Created on 17 сент€бр€ 2019 г., 7:11
  */

#ifndef GLRENDERSYSTEM_H
#define GLRENDERSYSTEM_H
#define PI 3.14159265359


#include "Vertices.h"

<<<<<<< HEAD
namespace Vintall {
    namespace GraphCore {
        class GLRenderer
        {
        public:
=======
            }

            void renderTriangleArray(GLfloat vertices[], GLfloat colors[]) {
            }
        };

        class GLRendererOld2_1 : public GLRenderSystem {

>>>>>>> parent of 0a66888 (added lab_2)
            void init() {
                if (!glfwInit()) {
                    fprintf(stderr, "ќшибка при инициализации GLFW\n");
                }
                glfwWindowHint(GLFW_SAMPLES, 4);
                glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 2);
                glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 1);

            }
            int colorRGB = 1;
            void render(GLFWwindow* window) 
            {
                glfwMakeContextCurrent(window);

                glClearColor(sin(colorRGB * PI / 180), abs(cos(colorRGB * PI / 180)), abs(sin(colorRGB * PI / 180) + cos(colorRGB * PI / 180)), 1.0f);
                glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
                {
                    colorRGB <= 180 ? colorRGB += 0.1f : colorRGB = 0.0f;
                }

                glEnable(GL_DEPTH_TEST);
                glMatrixMode(GL_MODELVIEW);
                glPushMatrix();

                glRotatef(sin(glfwGetTime()) * 45.f, cos(glfwGetTime()) * 45.f, 45.f, 1.f);
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

                glfwSwapBuffers(window);
                glfwPollEvents();
            }
        };
    }
}


#endif

