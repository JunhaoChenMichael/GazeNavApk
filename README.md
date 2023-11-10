# GazeNavApk

## Inspiration 

In a journey marked by empathy and innovation, one of my best friends living with Motor Neurone Disease (MND) became the cornerstone of inspiration for this project. Observing his daily struggles with conventional technology, I was deeply moved to explore a solution that transcends the boundaries of physical limitations. This led to the conception of a unique VR/AR user interface, solely operated by gaze and blink, negating the need for any physical handlers and hand gestures.

We have been doing research on eye gaze as an XR interface using Pico 3 NeoPro Eye in the context of public safety scenarios. When we heard about Pico Dev Jam, we concentrated on blink as a novel XR interaction.


## Implementation

We first brainstormed about the main idea and features that we were going to apply, and the purpose of this project. After that, we drew some paradigms for the UI and scene we need to work through. We have set up the developing environment and experimented with the features required in our project, like video seethrough, gaze tracking, and blink detection. After all of those preparations, we built a prototype for the project, which includes all the basic functions we designed. During this process, we took advice from experts to optimize this prototype and added some new features that might be helpful for the user experience. 

## Challenges
The first thing is we are not familiar with the PICO SDK, it took us some time to read and understand. The second is none of us good at UI design and animation, which could definitely increase the user experience. Thus we invited Lindsey to join us and made some high-quality textures for this project. We also implemented some animations ourselves and made good progress. 


FROM OUR ORIGINAL WRITE-UP TO GET IDEAS:
Gaze tracking is a rapidly developing field of research, and there have been a number of recent advances in gaze tracking for XR. For example, new eye-tracking hardware is becoming more accurate and affordable, and new software algorithms are being developed to improve the accuracy and robustness of gaze tracking in real-world environments.

This project explores the possibility of using eye gaze tracking and blink for user interaction in XR scenes. 

The incorporation of gaze tracking technology presents a significant advantage by liberating users' hands, thereby allowing them to perform other critical tasks, such as holding tools by first responders or medical personnel. For instance, first responders and medical professionals can continue to utilize their hands for essential tools or procedures while simultaneously interacting with digital information through eye movements. This seamless integration of gaze-based interactions within VR (Virtual Reality) scenes and selecting items with a simple blink, creates a more efficient and intuitive experience.

To enhance user engagement, we will introduce an interactive side menu for each object within the scene. This menu will expand the functionality and interactivity of objects, providing users with additional information and actions that can be accessed through gaze selection. Furthermore, our project will prioritize user comfort and adaptability, ensuring that the gaze tracking system is responsive and accurate without causing undue strain or fatigue.
By pushing the boundaries of XR technology, we aim to create immersive and practical experiences that cater to a diverse range of needs. Whether it's aiding emergency responders in critical situations, assisting surgeons during complex medical procedures, or enabling individuals with disabilities to interact with technology in new ways, the potential applications of gaze tracking in XR scenes are vast and compelling. This project stands at the intersection of technology and human-centric design, endeavoring to make XR experiences more intuitive, accessible, and effective for all users.

### Eye Gaze Selection

The gaze tracking was physically supported by the Pico Neo 3 Pro Eye, which has a built-in Tobii gaze sensor. We utilized the data that was provided by the Tobii sensor and other supportive functions to build our own tracking and reaction system. This system could successfully track the focus point of the user's eyes and be able to separately operate with the attributions of both eyes, which paved the way for the blink trigger. We have designed a series of smooth icons for an intuitive user experience and set an appropriate focus point transfering threshold to provide users from incidental focus loss.



### Blink Trigger

Based on a previous literature survey, we designed an intuitive and user-friendly method of action trigger, which is blink. Instead of using a single blink, which naturally happens for humans at a frequency of about one dozen times per minute, we used a double-blink for trigger action. This method was implemented by detecting the eyes’ openness switching and the time interval between blinks. The combination of gaze tracking and blink trigger provides the possibility of having intuitive interaction with AR scenes without using controllers or any other auxiliary devices.

## What did you learn? TBD
