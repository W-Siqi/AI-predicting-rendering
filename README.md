# AI-predicting-rendering
This is a tech demo, showing how we use marchine learning to generate **environment map** from a 2D backgound picture. Then we use this **evniroment map** to do the lighting calculation for the 3D model in the scene.   
## on-going plan:
1. Integrate the machine learning part to complete the whole pipeline.
2. A web demo allow to choose any background picture and 3D model and then generate the output online
3. An AR demo that do the light calculating in real-time to matchi the object with envirnment 

## application scenario & problems we solve  :
1. **AR/MR:** we render 3D object in real physical scene, but the lighting will not change with the phycisal conditions because it is totally defined manually at the start. So the lighting of objects doesn't match with environment.

2. **Advertising:** In TV product placement. The products are placed when TV is shot. So those are fixed after the shooting is done.  
To insert product into a existing video, we need the lighting information so the model "merge" with the video
3. **Flim:** In after effects, like those in science fictions, add model into the scene is very common. Lighting is conrolled by artists, or in some case, we use real camera to shoot the enviroment map. 

# Examples
## indoor examples
### rendering result-1:
![image](https://raw.githubusercontent.com/W-Siqi/AI-predicting-rendering/master/Resources/result1.png)
### enviroment map-1:
![image](https://raw.githubusercontent.com/W-Siqi/AI-predicting-rendering/master/Resources/envmap1.png)
### render result-2:
![image](https://raw.githubusercontent.com/W-Siqi/AI-predicting-rendering/master/Resources/result2.png)
### enviroment map-2:
![image](https://raw.githubusercontent.com/W-Siqi/AI-predicting-rendering/master/Resources/envmap2.png)
## outdoor examples
### rendering result-3: 
![image](https://raw.githubusercontent.com/W-Siqi/AI-predicting-rendering/master/Resources/result3.png)
### environment map-3:
![image](https://raw.githubusercontent.com/W-Siqi/AI-predicting-rendering/master/Resources/envmap3.png)


# Pipeline overview 
1. **The input:** 2D background picture + 3D model(no lighting)    
2. **The output:** the picutre witch 3D model's lighting fitts the background  
3. **The key to render:** the 3D model: get the environment map of [image-based-lighting](https://github.com/W-Siqi/AI-predicting-rendering/blob/master/Reference/Image-Based%20Lighting.pdf)  
4. **How get this environment map:** use [mechine learning](#Main-reference) technique by distinguishing indoor and outdoor cases.


![image](https://raw.githubusercontent.com/W-Siqi/AI-predicting-rendering/master/Resources/flowChart.png)
## The part this repo cover?
the Unity project includes how to use image-based-lighting to render the object with the output of light prediecting.  
more future works are mentioned in [on-going plan](#AI-predicting-rendering)
## Why we distinguish indoor and outdoor cases?
The enviroment map in [indoor expamples](#indoor-examples) and [outdoor examples](#outdoor-examples) are different. Because we treat it in different way.  
Why? Because the outdoor light source is mainlly contributed by sun. It is a single light source case, so we can parameterize the sky with sky model metioned in [reference](#Main-reference).  
But in indoor cases, the light source is extremely unpredictable and complex. So we use an end-to-end method to generate a HDR map.  
To sum up, because of the simple lighting conditions and its universality. We distinguish outdoor case to optimize it.
# Main reference
Render object:   
[image-based-lighting](https://github.com/W-Siqi/AI-predicting-rendering/blob/master/Reference/Image-Based%20Lighting.pdf)  

[synthetic object rendering](https://github.com/W-Siqi/AI-predicting-rendering/blob/master/Reference/Rendering%20Synthetic%20Objects%20into%20Real%20Scenes.pdf)   


Get enviroment map from indoor cases:   
[outdoor illumination](https://github.com/W-Siqi/AI-predicting-rendering/blob/master/Reference/deep%20outdoor%20%20Illumination%20Estimation.pdf)

Get enviroment map from outdoor cases:   
[predict indoor illumination](https://github.com/W-Siqi/AI-predicting-rendering/blob/master/Reference/Learning%20to%20Predict%20Indoor%20Illumination%20from%20a%20Single%20Image.pdf)  

The way we parameterize sky (describe the outdoor lighting):  
[Sky light model](https://github.com/W-Siqi/AI-predicting-rendering/blob/master/Reference/HosekWilkie_SkylightModel_SIGGRAPH2012_Preprint_lowres.pdf)