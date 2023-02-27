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

TERMINAL=gnome-terminal 
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



![](f519bdc28d276c276236b65ca2296f14.png)

![](9960713bc923fc8674ae7340c7de46f8.png)


![](5e3fc36b9809ff9627ea0a8e2a8fdcfd.png)

![](ecd1530fdf5b297d5b041359521cd091.png)



![](5e87a5afcb4800c740c6a533cb755453.png)

![](099a58315b8c25f2f02bf7c468065ada.png)

On the retina there are special cells called rods, sensible to light intensity,
and cones, sensible to light color. These cells allow the brain to see.

There are three different types of cones (sometimes called p, B, vy), all
equally distributed over the retina.

![](ab8520332f81e1d56b2a222993884d2f.png)


However, current graphics adapters are able to draw everything
supporting just three types of primitives:

* Points: basically a pixel or a set of pixel which are "closer" to a coordinate
* Lines
* Filled triangles

Current displays are able to show different resolutions, and are available in different sizes and form factors.

Applications want to display the same content regardless of the resolution, the size and the shape of the screen. They also want to exploit all the features of the display at their best.

A special coordinate system, called Normalized Screen Coordinates is used to address points on screen in a device independent way. 


Normalized Screen Coordinates are a Cartesian coordinate system, where x and y values range between two canonical values (generally between -1 and 1, but other standards such as 0 and 1 also exists), and axes oriented along a specific direction.


![](3ade08b503d295a6d49a913e0401c23a.png))

Both OpenGL and Vulkan uses normalized screen
coordinates in the [-1, 1] range.

However, OpenGL has the y-axis going up, while Vulkan follows the
convention of pixel coordinates with the y-axis pointing down.

As we introduced, screen buffers are usually accessed using their drivers and specific software libraries.

The primitives used to draw on the screen (or on one of its windows) automatically perform the computations to determine the correct pixels on the screen starting from normalized screen coordinates.

Software always uses Normalized Screen Coordinates, unless it works at a very low level in which it has to directly communicate with the frame buffer.



The x, y, and z coordinates of the vector with w = 1 identify the “real” position of the point in the 3D space. 


$$
(x, y, z, w) \rightarrow\left(x^{\prime}, y^{\prime}, z^{\prime}\right)=\left(\frac{x}{w}, \frac{y}{w}, \frac{z}{w}\right)
$$

$$
(x, y, z) \rightarrow(x, y, z, 1)
$$


The process of varying the coordinates of the points of an object in the space is called transformation. Transformation in 3D can be quite complex, since all the points of the object might be repositioned in a three-dimensional space. However, there is an important and large set of transformations that can be summarized with a mathematical concept known as the **affine transforms**. 

The affine transforms are usually grouped in four classes:

• Translation
• Scaling: enlarge, shrink, deform, mirror, flatten
• Rotation
• Shear

![](96fef8a5d5c2e5c07adb7df65c3976cd.png)


When using homogeneous coordinates, 4x4 matrices can express
the considered geometrical transforms.
The new vertex p' can be computed from the old point p by simply
multiplying it with the corresponding transform matrix M.
The basic transformations we are considering, are constructed to
maintain the fourth component of the resulting vector unchanged.

When using homogeneous coordinates, 4x4 matrices can express the considered geometrical transforms. The new vertex p' can be computed from the old point p by simply multiplying it with the corresponding transform matrix M. The basic transformations we are considering, are constructed to maintain the fourth component of the resulting vector unchanged. 


$$
\begin{array}{ll}
p=(x, y, z, 1) & p=(x, y, z, 1) \\
p^{\prime}=\left(M \cdot p^T\right)^T & p^{\prime}=p \cdot M^T \\
p^{\prime}=\left(x^{\prime}, y^{\prime}, z^{\prime}, 1\right) & p^{\prime}=\left(x^{\prime}, y^{\prime}, z^{\prime}, 1\right)
\end{array}
$$

Some books, libraries or game engine will use matrix-on-the-left or matrix-on-the-right. 


At this moment let's try to imagine how each transformation is represented with a matrix without actually reading the next lines. 


Translations use the last column only.

$$
M=\left|\begin{array}{ccc:c}
n_{x x} & n_{y x} & n_{z x} & d_x \\
n_{x y} & n_{y y} & n_{z y} & d_y \\
n_{x z} & n_{y z} & n_{z z} & d_z \\
\hdashline 0 & 0 & 0 & 1
\end{array}\right|=\left|\begin{array}{c:c}
M_R & \mathbf{d}^T \\
\hdashline \mathbf{0} & 1
\end{array}\right|
$$

the matrix product exchanges the three Cartesian axis
of the original coordinate system, with three new directions.

The columns in the sub-matrix  represent the directions and sizes of the new axes in the old reference system 

$$
M=\left|\begin{array}{ccc}
n_{x x} & n_{y x} & n_{z x} \\
n_{x y} & n_{y y} & n_{z y} \\
n_{x z} & n_{y z} & n_{z z} \\
\end{array}\right|
$$

![](3304ce6bd4befab7ed086bf252b920cc.png)

Each $j$-th column rapresent the "new direction" of the $j$-th column.  


Vector $\vec  d$ represents the position of the origin of the new coordinates system in the old one.


$$
\vec d=\left|\begin{array}{c}
d_x \\
d_y \\
d_z \\
\end{array}\right|
$$
![](f3caaa06db578a232687ddab85df1c67.png)

# Transformations 

###  Translation

$$
\begin{aligned}
& x^{\prime}=x+d_x \\
& y^{\prime}=y+d_y \\
& z^{\prime}=z+d_z
\end{aligned}
$$
$$
T\left(d_x, d_y, d_z\right)=\left|\begin{array}{cccc}
1 & 0 & 0 & d_x \\
0 & 1 & 0 & d_y \\
0 & 0 & 1 & d_z \\
0 & 0 & 0 & 1
\end{array}\right|
$$

The new coordinates can be obtained by simply adding the corresponding movement to each axis

### Scaling

$$
\begin{aligned}
& x^{\prime}=s_x \cdot x \\
& y^{\prime}=s_y \cdot y \\
& z^{\prime}=s_z \cdot z
\end{aligned}
$$
Proportional scaling is obtained using identical scaling factors.
$$
S\left(s_x, s_y, s_z\right)=\left|\begin{array}{cccc}
s_x & 0 & 0 & 0 \\
0 & s_y & 0 & 0 \\
0 & 0 & s_z & 0 \\
0 & 0 & 0 & 1
\end{array}\right|
$$

Mirroring can be obtained by using negative scaling factors.

Planar mirroring creates the symmetric object with respect to a plane.

$$
\begin{aligned}
& s_x=-1 \\
& s_y=1 \\
& s_z=1
\end{aligned}
$$

![](467398444e02571cbf190c4e8a13681d.png)


Axial mirroring creates the symmetric object with respect to an axis. It is obtained by assigning -1 to all the scaling factors but the one of the axis (x and z for y-axis).


$$
\begin{aligned}
& S_x=-1 \\
& s_y=1 \\
& S_z=-1
\end{aligned}
$$


![](deced9d8cfbd36ff80c44960483b7df8.png)

Central mirroring creates the symmetric object with respect to the origin.

![](cfef958c36fca42865ae5106a1e5678b.png)
$$
\begin{aligned}
& s_x=-1 \\
& s_y=-1 \\
& s_z=-1
\end{aligned}
$$



### Rotation

![](812bbf6ee10c8069e3247b62968acf1b.png)


x-axis
$$
\begin{aligned}
& x^{\prime}=x \\
& y^{\prime}=y \cdot \cos \alpha-z \cdot \sin \alpha \\
& z^{\prime}=y \cdot \sin \alpha+z \cdot \cos \alpha \\
\end{aligned}
$$
$$
\begin{aligned}
&R_x(\alpha)=\left|\begin{array}{cccc}
1 & 0 & 0 & 0 \\
0 & \cos \alpha & -\sin \alpha & 0 \\
0 & \sin \alpha & \cos \alpha & 0 \\
0 & 0 & 0 & 1
\end{array}\right|
\end{aligned}
$$


y-axis
$$\begin{aligned} \\
& x^{\prime}=x \cdot \cos \alpha+z \cdot \sin \alpha \\
& y^{\prime}=y \\
& z^{\prime}=-x \cdot \sin \alpha+z \cdot \cos \alpha \\
\end{aligned}
$$ 


$$
\begin{aligned}
&R_y(\alpha)=\left|\begin{array}{cccc}
\cos \alpha & 0 & \sin \alpha & 0 \\
0 & 1 & 0 & 0 \\
-\sin \alpha & 0 & \cos \alpha & 0 \\
0 & 0 & 0 & 1
\end{array}\right|
\end{aligned}
$$

z-axis
$$\begin{aligned}\\
& x^{\prime}=x \cdot \cos \alpha-y \cdot \sin \alpha \\
& y^{\prime}=x \cdot \sin \alpha+y \cdot \cos \alpha \\
& z^{\prime}=z \\
\end{aligned}
$$

$$
\begin{aligned}
&R_z(\alpha)=\left|\begin{array}{cccc}
\cos \alpha & -\sin \alpha & 0 & 0 \\
\sin \alpha & \cos \alpha & 0 & 0 \\
0 & 0 & 1 & 0 \\
0 & 0 & 0 & 1
\end{array}\right|
\end{aligned}
$$

### Shear

The shear transform bends an object in one direction. Shear is performed along an axis and has a center. We initially focus on the y-axis passing through the origin.

$$
\begin{aligned}
& x^{\prime}=x \\
& y^{\prime}=y+x \cdot h_y \\
& z^{\prime}=z+x \cdot h_z \\
& x^{\prime}=x+y \cdot h_x \\
& y^{\prime}=y \\
& z^{\prime}=z+y \cdot h_z \\
& x^{\prime}=x+z \cdot h_x \\
& y^{\prime}=x+z \cdot h_y \\
& z^{\prime}=z
\end{aligned}
$$

$$
\begin{aligned}
& H_x\left(h_y, h_z\right)=\left|\begin{array}{cccc}
1 & 0 & 0 & 0 \\
h_y & 1 & 0 & 0 \\
h_z & 0 & 1 & 0 \\
0 & 0 & 0 & 1
\end{array}\right| \\
& H_y\left(h_x, h_z\right)=\left|\begin{array}{cccc}
1 & h_x & 0 & 0 \\
0 & 1 & 0 & 0 \\
0 & h_z & 1 & 0 \\
0 & 0 & 0 & 1
\end{array}\right| \\
& H_z\left(h_x, h_y\right)=\left|\begin{array}{cccc}
1 & 0 & h_x & 0 \\
0 & 1 & h_y & 0 \\
0 & 0 & 1 & 0 \\
0 & 0 & 0 & 1
\end{array}\right|
\end{aligned}
$$

Note that the last row in all the 4x4 transformation matrices is always
Some engines exploit this to save memory. 


