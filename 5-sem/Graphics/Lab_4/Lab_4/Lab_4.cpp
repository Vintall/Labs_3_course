#include <iostream>
#include <string>

#include <glew.h>
#include <glfw3.h>


#include "GLShader.h"
#include "Vertices.h"

#include "GLWindow.h"
#include "GLRenderSystem.h"
#include "stb_image.h"

#include "MyModel.h"


#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

const unsigned int SCR_WIDTH = 800;
const unsigned int SCR_HEIGHT = 600;
#define HATE_C++
int main(int argc, char** argv)
{
#ifdef HATE_C++
        fprintf(stdout, "Made by Vintall");
        Vintall::GLWindow* my_window = new Vintall::GLWindow("Lab_4_Vintall", 640, 480);
        

        glfwMakeContextCurrent(my_window->getGLFWHandle());

        glewExperimental = true;
        if (glewInit() != GLEW_OK)
        {
            fprintf(stderr, "Невозможно инициализировать GLEW\n");
            return -1;
        }
#endif // InstantiateWindow


    Shader* shader = new Shader("BrightAndDim_VertexShader.vs", "BrightAndDim_FragmentShader.fs");
    Model* pumpkin = new Model("Survival_BackPack_2.fbx");
    
    unsigned int texture;
    glGenTextures(1, &texture);
    glBindTexture(GL_TEXTURE_2D, texture);
    // load and generate the texture
    int width, height, nrChannels;
    unsigned char* data = stbi_load("1001_albedo.jpg", &width, &height, &nrChannels, 0);
    if (data)
    {
        glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_RGB, GL_UNSIGNED_BYTE, data);
        glGenerateMipmap(GL_TEXTURE_2D);

    }
    stbi_image_free(data);
    shader->use();
    shader->setInt("albedo", GL_TEXTURE_2D);
    
    glm::mat4 projection = glm::perspective(glm::radians(45.0f), (float)SCR_WIDTH / (float)SCR_HEIGHT, 0.1f, 100.0f);
    shader->setMat4("projection", projection);

    while (glfwGetKey(my_window->getGLFWHandle(), GLFW_KEY_ESCAPE) != GLFW_PRESS && glfwWindowShouldClose(my_window->getGLFWHandle()) == 0)
    {
        glfwMakeContextCurrent(my_window->getGLFWHandle());

        float x_angle = sin(glfwGetTime());
        float y_angle = cos(glfwGetTime());
        float z_angle = 2 * sin(glfwGetTime());

        shader->setFloat("angle_x", x_angle);
        shader->setFloat("angle_y", y_angle);
        shader->setFloat("angle_z", z_angle);
        
        glm::mat4 view = glm::mat4(1.0f); // make sure to initialize matrix to identity matrix first
        float radius = 10.0f;
        float camX = sin(glfwGetTime()) * radius;
        float camZ = cos(glfwGetTime()) * radius;
        view = glm::lookAt(glm::vec3(camX, 0.0f, camZ), glm::vec3(0.0f, 0.0f, 0.0f), glm::vec3(0.0f, 1.0f, 0.0f));
        shader->setMat4("view", view);

        pumpkin->Draw(*shader);

        glfwSwapBuffers(my_window->getGLFWHandle());
        glfwPollEvents();
        glfwMakeContextCurrent(my_window->getGLFWHandle());
    }

    glfwDestroyWindow(my_window->getGLFWHandle());
    glfwTerminate();
    return 0;
}

//void resize(GLFWwindow* window, int width, int height)
//{
//    float ratio = width / (float)height;
//    glViewport(0, 0, width, height);
//
//    glClear(GL_COLOR_BUFFER_BIT);
//    glMatrixMode(GL_PROJECTION);
//    glLoadIdentity();
//    glOrtho(-ratio, ratio, -1.f, 1.f, 1.f, -1.f);
//    glMatrixMode(GL_MODELVIEW);
//    glLoadIdentity();
//}

//void keyCallback(GLFWwindow* window, int key, int scancode, int action, int mode)
//{
//    //println((string)"key:" + key + "-scancode:" + scancode + "-action:" + action + "-mode:" + mode);
//
//    if (key == GLFW_KEY_SPACE && action == GLFW_PRESS) {
//        //println("SPACE");
//        //TO DO
//    }
//}
