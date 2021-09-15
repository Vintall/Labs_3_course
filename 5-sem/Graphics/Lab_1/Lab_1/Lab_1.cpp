#include <GL/glew.h>
#include <GLFW/glfw3.h>
#include <iostream>

int main(void)
{
    GLFWwindow* window;
   

    if (!glfwInit())
        return -1;

    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 1);

    std::cout << "Hello OpenGL" << std::endl;
    std::cout << "Author: Ilyashenko Egor" << std::endl;

    window = glfwCreateWindow(640, 480, "Lab_1_Ilyashenko", NULL, NULL);
    if (!window)
    {
        glfwTerminate();
        return -1;
    }

    float vertices[] = {
    -0.5f, -0.5f, 0.0f,
     0.5f, -0.5f, 0.0f,
     0.0f,  0.5f, 0.0f
    };

    glfwMakeContextCurrent(window);

    while (!glfwWindowShouldClose(window))
    {
        glClear(GL_COLOR_BUFFER_BIT);

        glColor3b(255, 0, 0);
        glDrawArrays(GL_TRIANGLES, 0, 3);

        glfwPollEvents();

        glfwSwapBuffers(window);
    }

    glfwTerminate();
    return 0;
}
