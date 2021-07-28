
# ClientServer

This was another 'play' project but I actually ran it 24/7-ish in 2011 for a while. Security cams at the time were either expensive or required cable installation. So I setup an old PC in my garage and mounted the webcam on the eve outside. I had tried TCPClient in .Net initially but knew too little about how to build a robust network system at the time and settled on remote objects, in this case a 'RemoteImage'. In the AForgeTest project I obviously used AForge but in this one I used Emgu.CV for image capture.

The server would run on this garage PC and capture an image from the webcam.

![Server](/server.PNG)

Then I could run the client app from my PC inside the house to see a live updated image feed. There's a corny alter message when movement is detected. I didn't implement this well and recieved far too many alerts. I basically left that off.

![Client](/client.PNG)

### Code

I doubt many people would be interested in this but a working implementation of remote objects in .Net could be educational. Otherwise, the image manipulation code might work ok. But be warned, I used GDI+ so it's slow and uses a non-trivial amount of CPU...or, it did at the time. CPUs are much faster today than in 2011. 

![Imagefilters](/imagefilters.PNG)

### Finally

I ended up buying a security cam and replaced this 'solution' but there was a secondary problem while running it. The garage PC couldn't be grounded because of the age of my house and the 2 prong electrical system. The chasis would build a charge over the course of a week and shut itself down. I would get a mild shock each time I touched it when resetting it. Funny situation, hope you got a chuckle out of it.