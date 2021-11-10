<<<<<<< HEAD
﻿#include <iostream>

#include <glew.h>
#include <glfw3.h>
#include "Vertices.h"
=======
﻿#include <GL/glew.h>
#include <GLFW/glfw3.h>
#include <iostream>
>>>>>>> parent of 0a66888 (added lab_2)

#include "GLWindow.h"
#include "GLRenderSystem.h"

using namespace std;

int main(int argc, char** argv) {

<<<<<<< HEAD
    Vintall::GraphCore::GLRenderer* renderer = new Vintall::GraphCore::GLRenderer();
=======
    Knight3D::GraphCore::GLRenderSystem* renderer = new Knight3D::GraphCore::GLRenderSystem();

>>>>>>> parent of 0a66888 (added lab_2)
    renderer->init();

    Vintall::GLWindow* Win1 = new Vintall::GLWindow("Lesson 021", 320, 240);
    glfwMakeContextCurrent(Win1->getGLFWHandle());

<<<<<<< HEAD
    glewExperimental = true;
    if (glewInit() != GLEW_OK)
    {
        fprintf(stderr, "Невозможно инициализировать GLEW\n");
        return -1;
    }
    while (glfwGetKey(Win1->getGLFWHandle(), GLFW_KEY_ESCAPE) != GLFW_PRESS && glfwWindowShouldClose(Win1->getGLFWHandle()) == 0)
    {
=======
    Knight3D::GLWindow* Win1 = new Knight3D::GLWindow("Lesson 021", 320, 240);
    Knight3D::GLWindow* Win2 = new Knight3D::GLWindow("Lesson 022", 640, 480);

    Cube::init();

    // Проверяем нажатие клавиши Escape или закрытие окна
    while (glfwGetKey(Win1->getGLFWHandle(), GLFW_KEY_ESCAPE) != GLFW_PRESS &&
        glfwWindowShouldClose(Win1->getGLFWHandle()) == 0) {


>>>>>>> parent of 0a66888 (added lab_2)
        glfwMakeContextCurrent(Win1->getGLFWHandle());

<<<<<<< HEAD
        renderer->render(Win1->getGLFWHandle());
=======

        glfwMakeContextCurrent(Win2->getGLFWHandle());
        renderer->render(Win2->getGLFWHandle());
        
            glfwSwapBuffers(Win2->getGLFWHandle());
>>>>>>> parent of 0a66888 (added lab_2)

        glfwMakeContextCurrent(Win1->getGLFWHandle());
    }

<<<<<<< HEAD
=======

    glDeleteBuffers(1, &Cube::VBO);

>>>>>>> parent of 0a66888 (added lab_2)
    glfwDestroyWindow(Win1->getGLFWHandle());
    glfwTerminate();
    return 0;
}