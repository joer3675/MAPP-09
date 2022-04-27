//using system.collections;
//using system.collections.generic;
//using unityengine.ui;
//using system.io;
//using unityengine;

//public class cameratest : monobehaviour
//{

//    public rawimage rawimage;  //image for rendering what the camera sees.
//    webcamtexture webcamtexture = null;

//    void start()
//    {
//        //save get the camera devices, in case you have more than 1 camera.
//        webcamdevice[] camdevices = webcamtexture.devices;

//        //get the used camera name for the webcamtexture initialization.
//        string camname = camdevices[0].name;
//        webcamtexture = new webcamtexture(camname);

//        //render the image in the screen.
//        rawimage.texture = webcamtexture;
//        rawimage.material.maintexture = webcamtexture;
//        webcamtexture.play();
//    }

//    void update()
//    {
//        //this is to take the picture, save it and stop capturing the camera image.
//        if (input.getmousebuttondown(0))
//        {
//            saveimage();
//            webcamtexture.stop();
//        }
//    }

//    void saveimage()
//    {
//        //create a texture2d with the size of the rendered image on the screen.
//        texture2d texture = new texture2d(rawimage.texture.width, rawimage.texture.height, textureformat.argb32, false);

//        //save the image to the texture2d
//        texture.setpixels(webcamtexture.getpixels());
//        texture.apply();

//        //encode it as a png.
//        byte[] bytes = texture.encodetopng();

//        //save it in a file.
//        file.writeallbytes(application.datapath + "/images/testimg.png", bytes);
//    }
//}