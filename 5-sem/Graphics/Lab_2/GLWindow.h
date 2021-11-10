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

namespace Vintall {

    class GLWindow {
    public:
<<<<<<< HEAD
        GLWindow(const std::string& title, uint32_t width, uint32_t height)
        {
            window = glfwCreateWindow(width, height, "sdf", NULL, NULL);
            this->width = width;
            this->height = height;
        }
=======
        GLWindow(const std::string& title, uint32_t width, uint32_t height);
        GLWindow(const std::string& title, uint32_t width, uint32_t height, GLFWwindow* share);

>>>>>>> parent of 0a66888 (added lab_2)
        ~GLWindow() {
            glfwDestroyWindow(getGLFWHandle());
        };
        uint32_t getWidth() const;
        uint32_t getHeight() const;

        GLFWwindow* getGLFWHandle() const;
    private:
<<<<<<< HEAD
        GLFWwindow* window;
        uint32_t width, height;
=======
        // TODO

>>>>>>> parent of 0a66888 (added lab_2)
    };
}
#endif

