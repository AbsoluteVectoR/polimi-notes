https://vulkan.lunarg.com/sdk/home

https://vulkan-tutorial.com/Development_environment

https://github.com/glfw/glfw

After installing the Vulkan SDK on Linux, you can find the SDK files in the installation directory. The default installation directory is `/usr/share/vulkan`

Vulkan SDK includes several tools and libraries that you can use to develop Vulkan applications, such as:

-   `vulkaninfo`: A command-line tool that displays information about the Vulkan implementation and the available graphics devices.
    
-   `GLFW`: A library that provides a simple API for creating windows, contexts, and handling input. It also includes support for Vulkan.
    
-   `Vulkan Memory Allocator`: A library that provides an easy-to-use interface for managing Vulkan memory.
    
-   `SPIRV-Tools`: A set of tools for working with SPIR-V shader modules.

To get started with developing Vulkan applications using VS Code, you can follow these steps:
	
1.  Install the C/C++ extension for VS Code.
2.  Create a new C/C++ project and configure it to use the Vulkan SDK.
3.  Write your Vulkan application code and build it using a build system such as CMake.
4.  Run your application and test it on your Vulkan-capable graphics device.



Following the tutorial on:
https://vulkan-tutorial.com/Development_environment
Install your own Vulkan development environment.



There are two Makefiles, one that compiles the shaders and doesn't do it. Just copy the needed one into the _Makefile_ file. Then just change _DIR_ and _NAME_ with the directory name and the main file name of the assignment (ex. DIR=A01, NAME=Assignment01). Then open a terminal and type:

make

The Makefile works by using the `make` command to read the rules and dependencies defined in the Makefile and then executing the commands necessary to build the program. When `make` is run, it compares the timestamps of the source files and the build artifacts to determine which files need to be recompiled and which ones can be reused, which can help save time and avoid unnecessary recompilation.

One of the main benefits of using a Makefile is that it can automate the build process and make it easier to manage complex projects with multiple files and dependencies. It can also help ensure that the build process is consistent across different platforms and configurations.


```shell
DIR=./A00
NAME=A00

ifndef DIR
$(error DIR is not set)
endif

ifndef NAME
$(error NAME is not set)
endif

FILEPATH=$(DIR)/$(NAME)
CFLAGS = -std=c++17 -O3
INCLUDE = -I$(DIR)/headers
LDFLAGS = -lglfw -lvulkan -ldl -lpthread -lX11 -lXxf86vm -lXrandr -lXi

all: clean build test  

build: $(FILEPATH).cpp
	g++ $(CFLAGS) -o $(FILEPATH) $(FILEPATH).cpp $(INCLUDE) $(LDFLAGS)

test: $(FILEPATH)
	cd $(DIR) && "./$(NAME)"

clean:
	rm -f $(FILEPATH)
```



