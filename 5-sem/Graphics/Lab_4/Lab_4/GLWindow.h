#pragma once

#ifndef GLWINDOW_H
#define GLWINDOW_H

#include <string>

namespace Vintall 
{

    class GLWindow 
    {
    public:
        GLWindow(const char* title, uint32_t width, uint32_t height)
        {
            if (!glfwInit()) {
                fprintf(stderr, "Ошибка при инициализации GLFW\n");
            }
            glfwWindowHint(GLFW_SAMPLES, 4);
            glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
            glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 0);


            window = glfwCreateWindow(width, height, title, NULL, NULL);
            this->width = width;
            this->height = height;
        }
        ~GLWindow() {
            glfwDestroyWindow(getGLFWHandle());
        };
        uint32_t getWidth()
        {
            return width;
        }
        uint32_t getHeight()
        {
            return height;
        }

        GLFWwindow* getGLFWHandle()
        {
            return window;
        }
    private:
        GLFWwindow* window;
        uint32_t width, height;
    };
}
#endif