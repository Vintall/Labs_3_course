/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

 /*
  * File:   GLWindow.h
  * Author: KnightDanila
  *
  * Created on 17 сент€бр€ 2019 г., 0:04
  */

#ifndef GLWINDOW_H
#define GLWINDOW_H

namespace Knight3D {

    class GLWindow {
    public:
        GLWindow(const std::string& title, uint32_t width, uint32_t height)
        {
            window = glfwCreateWindow(width, height, "sdf", NULL, NULL);
            this->width = width;
            this->height = height;
        }
        //GLWindow(const std::string& title, uint32_t width, uint32_t height, GLFWwindow* share);

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
#endif /* GLWINDOW_H */

