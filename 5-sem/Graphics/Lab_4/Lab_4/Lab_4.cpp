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


void framebuffer_size_callback(GLFWwindow* window, int width, int height);
void mouse_callback(GLFWwindow* window, double xpos, double ypos);
void scroll_callback(GLFWwindow* window, double xoffset, double yoffset);
void processInput(GLFWwindow* window);




bool firstMouse = true;
float yaw = -90.0f;	// yaw is initialized to -90.0 degrees since a yaw of 0.0 results in a direction vector pointing to the right so we initially rotate a bit to the left.
float pitch = 0.0f;
float lastX = 800.0f / 2.0;
float lastY = 600.0 / 2.0;
float fov = 45.0f;


const unsigned int SCR_WIDTH = 800;
const unsigned int SCR_HEIGHT = 600;
// timing
float deltaTime = 0.0f;	// time between current frame and last frame
float lastFrame = 0.0f;

glm::vec3 cameraPos = glm::vec3(0.0f, 0.0f, 3.0f);
glm::vec3 cameraFront = glm::vec3(0.0f, 0.0f, -1.0f);
glm::vec3 cameraUp = glm::vec3(0.0f, 1.0f, 0.0f);

Vintall::GLWindow* my_window;
Shader* shader;
Model*dirt, *grass, *stone;
void InitWindow()
{
    my_window = new Vintall::GLWindow("Lab_4_Vintall", 640, 480);

    glfwMakeContextCurrent(my_window->getGLFWHandle());
    glewExperimental = true;
    if (glewInit() != GLEW_OK)
    {
        fprintf(stderr, "Невозможно инициализировать GLEW\n");
        exit(0);
    }
    
}
void InitModel()
{
    shader = new Shader("BrightAndDim_VertexShader.vs", "BrightAndDim_FragmentShader.fs");
    shader->use();
    dirt = new Model("dirt/cube.fbx");
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
    grass = new Model("grass/cube.fbx");
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
    stone = new Model("stone/cube.fbx");
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
}
int map_size = 10;


int MapSinX(int coord, int max_value)
{
    int result;
    double sin_res = sin(coord) * 5;

    return sin_res < 0 ? -1 * (int)sin_res : (int)sin_res;
}
int MapSinY(int coord, int max_value)
{
    int result;
    double sin_res = sin(coord+0.5f) * 5;

    return sin_res < 0 ? -1 * (int)sin_res : (int)sin_res;
}
int*** InitMap() //0-air  1-stone  2-dirt  3-grass
{
    int*** map_ = new int** [map_size];

    for (int i = 0; i < map_size; i++)
    {
        map_[i] = new int* [map_size];
        for (int j = 0; j < map_size; j++)
            map_[i][j] = new int [map_size];
    }
    for (int i = 0; i < map_size; i++)
        for (int j = 0; j < map_size; j++)
            for (int k = 0; k < map_size; k++)
            {
                map_[i][j][k] = rand() % 2;
            }
    for (int i = 0; i < map_size; i++)
        for (int j = 0; j < map_size; j++)
            for (int k = 0; k < map_size; k++)
            {
                if (map_[i][j][k] == 1)
                {
                    for (int o = 0; o < map_size; o++)
                    {
                        if (map_[i][j][o] == 0)
                        {
                            map_[i][j][o] = 1;
                            map_[i][j][k] = 0;
                            break;
                        }
                    }
                }
            }
    int all_count;
    all_count = 0;
    for (int i = 0; i < map_size; i++)
        for (int j = 0; j < map_size; j++)
        {
            int count = 0;
            for (int k = 0; k < map_size; k++)
            {
                if (map_[i][j][k] != 0) 
                    count++;
                else 
                    break;
            }
            all_count += count;
        }
    all_count /= (map_size * map_size);
    for (int i = 0; i < map_size; i++)
        for (int j = 0; j < map_size; j++)
        {
            int row_count = 0;
            for (int k = 0; k < map_size; k++)
                if (map_[i][j][k] != 0)
                    row_count++;
                else 
                    break;
            row_count = (row_count + all_count) / 2;
            for (int k = 0; k < map_size; k++)
            {
                if (k < row_count)
                    map_[i][j][k] = 1;
                else
                    map_[i][j][k] = 0;
            }
        }
    for (int i = 0; i < map_size; i++)
        for (int j = 0; j < map_size; j++)
            for (int k = map_size-1; k >=0 ; k--)
            {
                if (map_[i][j][k] != 0)
                {
                    map_[i][j][k] = 3;
                    if (k - 1 >= 0)
                        map_[i][j][k - 1] = 2;
                    if (k - 1 >= 0)
                        map_[i][j][k - 2] = 2;
                    break;
                }
            }

    int*** map_buff = new int** [map_size];

    for (int i = 0; i < map_size; i++)
    {
        map_buff[i] = new int* [map_size];
        for (int j = 0; j < map_size; j++)
        {
            map_buff[i][j] = new int[map_size];
            for (int k = 0; k < map_size; k++)
            {
                map_buff[i][j][k] = map_[i][j][k];
            }
        }
    }

    for (int i = 1; i < map_size-1; i++)
        for (int j = 1; j < map_size - 1; j++)
            for (int k = 1; k < map_size - 1; k++)
            {
                if (map_[i][j][k] != 0 
                    && map_[i - 1][j][k] != 0
                    && map_[i][j - 1][k] != 0
                    && map_[i][j][k - 1] != 0
                    && map_[i + 1][j][k] != 0
                    && map_[i][j + 1][k] != 0
                    && map_[i][j][k + 1] != 0)
                {
                    map_buff[i][j][k] = 0;
                }
            }

    for (int i = 1; i < map_size - 1; i++)
        for (int j = 1; j < map_size - 1; j++)
            for (int k = 1; k <= map_size - 1; k++)
            {
                map_[i][j][k] = map_buff[i][j][k];
            }
    return map_;
}
int main(int argc, char** argv)
{
    if (argc == 2)
        map_size = atoi(argv[1]);

    fprintf(stdout, "Made by Vintall");
    InitWindow();
    InitModel();
    int*** map = InitMap();
    
    glfwMakeContextCurrent(my_window->getGLFWHandle());
    glfwSetFramebufferSizeCallback(my_window->getGLFWHandle(), framebuffer_size_callback);
    glfwSetCursorPosCallback(my_window->getGLFWHandle(), mouse_callback);
    glfwSetScrollCallback(my_window->getGLFWHandle(), scroll_callback);

    glfwSetInputMode(my_window->getGLFWHandle(), GLFW_CURSOR, GLFW_CURSOR_DISABLED);

    glEnable(GL_DEPTH_TEST);
    glEnable(GL_CULL_FACE);
    glCullFace(GL_FRONT_FACE);

    shader->use();

    glm::mat4 projection = glm::perspective(glm::radians(fov), (float)SCR_WIDTH / (float)SCR_HEIGHT, 0.1f, 100.0f);
    shader->setMat4("projection", projection);
    glfwMakeContextCurrent(my_window->getGLFWHandle());
    glClearColor(0.8f, 0.8f, 1, 1.0f);
    while (glfwGetKey(my_window->getGLFWHandle(), GLFW_KEY_ESCAPE) != GLFW_PRESS && glfwWindowShouldClose(my_window->getGLFWHandle()) == 0)
    {
        float currentFrame = glfwGetTime();
        deltaTime = currentFrame - lastFrame;
        lastFrame = currentFrame;

        processInput(my_window->getGLFWHandle());

        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        glm::mat4 view = glm::lookAt(cameraPos, cameraPos + cameraFront, cameraUp);
        shader->setMat4("view", view);


        glm::mat4 model = glm::mat4(1.0f);
        model = glm::rotate(model, glm::radians(-90.f), glm::vec3(1.0f, 0.f, 0.f));

        for (int i = 0; i < map_size; i++)
            for (int j = 0; j < map_size; j++)
                for (int k = 0; k < map_size; k++)
                {
                    model = glm::translate(model, glm::vec3(i * 2, j * 2, k * 2));
                    shader->setMat4("model", model);
                    switch (map[i][j][k])
                    {
                    case 1:
                        stone->Draw(*shader);
                        break;
                    case 2:
                        dirt->Draw(*shader);
                        break;
                    case 3:
                        grass->Draw(*shader);
                        break;
                    }
                    model = glm::translate(model, glm::vec3(-i * 2, -j * 2, -k * 2));
                }


        glfwSwapBuffers(my_window->getGLFWHandle());
        glfwPollEvents();
    }

    glfwDestroyWindow(my_window->getGLFWHandle());
    glfwTerminate();
    return 0;
}


void processInput(GLFWwindow* window)
{
    if (glfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)
        glfwSetWindowShouldClose(window, true);

    float cameraSpeed = 20 * deltaTime;
    if (glfwGetKey(window, GLFW_KEY_W) == GLFW_PRESS)
        cameraPos += cameraSpeed * cameraFront;
    if (glfwGetKey(window, GLFW_KEY_S) == GLFW_PRESS)
        cameraPos -= cameraSpeed * cameraFront;
    if (glfwGetKey(window, GLFW_KEY_A) == GLFW_PRESS)
        cameraPos -= glm::normalize(glm::cross(cameraFront, cameraUp)) * cameraSpeed;
    if (glfwGetKey(window, GLFW_KEY_D) == GLFW_PRESS)
        cameraPos += glm::normalize(glm::cross(cameraFront, cameraUp)) * cameraSpeed;
}

void framebuffer_size_callback(GLFWwindow* window, int width, int height)
{
    glViewport(0, 0, width, height);
}

void mouse_callback(GLFWwindow* window, double xpos, double ypos)
{
    if (firstMouse)
    {
        lastX = xpos;
        lastY = ypos;
        firstMouse = false;
    }

    float xoffset = xpos - lastX;
    float yoffset = lastY - ypos; // reversed since y-coordinates go from bottom to top
    lastX = xpos;
    lastY = ypos;

    float sensitivity = 0.1f; // change this value to your liking
    xoffset *= sensitivity;
    yoffset *= sensitivity;

    yaw += xoffset;
    pitch += yoffset;

    // make sure that when pitch is out of bounds, screen doesn't get flipped
    if (pitch > 89.0f)
        pitch = 89.0f;
    if (pitch < -89.0f)
        pitch = -89.0f;

    glm::vec3 front;
    front.x = cos(glm::radians(yaw)) * cos(glm::radians(pitch));
    front.y = sin(glm::radians(pitch));
    front.z = sin(glm::radians(yaw)) * cos(glm::radians(pitch));
    cameraFront = glm::normalize(front);
}

// glfw: whenever the mouse scroll wheel scrolls, this callback is called
// ----------------------------------------------------------------------
void scroll_callback(GLFWwindow* window, double xoffset, double yoffset)
{
    fov -= (float)yoffset;
    if (fov < 1.0f)
        fov = 1.0f;
    if (fov > 45.0f)
        fov = 45.0f;
}