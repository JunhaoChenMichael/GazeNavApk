# GazeNav

## Introduction
Gaze tracking is a rapidly developing field of research, and there have been a number of recent advances in gaze tracking for XR. For example, new eye-tracking hardware is becoming more accurate and affordable, and new software algorithms are being developed to improve the accuracy and robustness of gaze tracking in real-world environments.

This project explores the possibility of using eye-gaze tracking and blink for user interaction in XR scenes. 

The incorporation of gaze tracking technology presents a significant advantage by liberating users' hands, thereby allowing them to perform other critical tasks, such as holding tools by first responders or medical personnel. For instance, first responders and medical professionals can continue to utilize their hands for essential tools or procedures while simultaneously interacting with digital information through eye movements. This seamless integration of gaze-based interactions within VR and AR scenes and selecting items with eye-gaze and simple double-blinks creates a more efficient and intuitive experience.


## Inspiration 

In a journey marked by empathy and innovation, my best friend living with **Motor Neurone Disease** (_MND_) became the cornerstone of inspiration for GazeNav. Observing his daily challenges with conventional technology, I was driven to explore solutions beyond traditional physical limitations. This led to the conception of a unique VR/AR user interface, operated solely through **gaze** and **blink**, eliminating the need for physical handlers.

Besides assisting individuals with MND and other disabilities, the potential of this technology can be expanded to a wider spectrum of applications. We realized that our gaze and blink-controlled interface could be helpful for **firefighters**, **first responders**, and even in **surgical** settings, where hands are often occupied with critical tasks. For these professionals, the ability to interact with a UI to gain information, request assistance, or navigate complex environments hands-free could be invaluable. In high-pressure situations where every second counts, such as navigating through a burning building or performing delicate surgery, our system offers a way to access and relay information seamlessly without compromising the task at hand.

## Design

To enhance user engagement, we will introduce an interactive side menu for each object within the scene. This menu will expand the functionality and interactivity of objects, providing users with additional information and actions that can be accessed through gaze selection. Furthermore, our project will prioritize user comfort and adaptability, ensuring that the gaze tracking system is responsive and accurate without causing undue strain or fatigue.



## Implementation

Our research on eye gaze as an XR interface, particularly with the Pico Neo 3 Pro Eye and Pico 4 in public safety scenarios, laid the groundwork. The Pico Dev Jam inspired us to integrate blink as a novel XR interaction method.

We first brainstormed about the main idea and features that we were going to apply, and the purpose of this project. After that, we drew some paradigms for the UI and scene we need to work through. We have set up the developing environment and experimented with the features required in our project, like video seethrough, gaze tracking, and blink detection. After all of those preparations, we built a prototype for the project, which includes all the basic functions we designed. During this process, we took advice from experts to optimize this prototype and added some new features that might be helpful for the user experience. 

### Eye Gaze Selection

The gaze tracking was physically supported by the Pico Neo 3 Pro Eye, which has a built-in Tobii gaze sensor. We utilized the data that was provided by the Tobii sensor and other supportive functions to build our own tracking and reaction system. This system could successfully track the focus point of the user's eyes and be able to operate separately with the attributions of both eyes, which paved the way for the blink trigger. We have designed a series of smooth icons for an intuitive user experience and set an appropriate focus point transfer threshold to protect users from incidental focus loss.

### Blink Trigger

Based on a previous literature survey, we designed an intuitive and user-friendly method of action trigger, which is blink. Instead of using a single blink, which naturally happens for humans at a frequency of about one dozen times per minute, we used a double-blink for trigger action. This method was implemented by detecting the eyes’ openness switching and the time interval between blinks. The combination of gaze tracking and blink triggers provides the possibility of having intuitive interaction with AR scenes without using controllers or any other auxiliary devices.


## Challenges
The first thing is we are not familiar with the PICO SDK, it took us some time to read and understand. The second is none of us good at UI design and animation, which could definitely increase the user experience. Thus we invited Lindsey to join us and made some high-quality textures for this project. We also implemented some animations ourselves and made good progress. 


## What did you learn?
Throughout the development of GazeNavApk, our learning curve was steep but rewarding. Here are the key areas where we gained significant knowledge and expertise:

Mastering Pico Unity SDK: Our first major learning milestone was understanding and utilizing the Pico Unity SDK. This involved delving into the intricacies of the software, comprehending its documentation, and learning how to effectively integrate it into our project. Mastering this SDK was crucial, as it formed the backbone of our development process, enabling us to harness the full potential of the Pico Neo 3 Pro Eye hardware.

Working with Gaze and Blink Data: Another significant area of learning was in handling gaze and blink data. This entailed understanding the nuances of eye-tracking technology, particularly how to accurately capture and interpret gaze direction and blink patterns. We learned to differentiate between intentional and involuntary blinks, and how to translate these into meaningful interactions within our UI. This knowledge was critical in ensuring that our system was intuitive and responsive to the user's intentions.

UI Design for Eye-Based Interaction: Perhaps one of the most challenging and enlightening aspects was learning how to design a user interface specifically for eye-based interaction. This required a shift from traditional UI design principles, as we had to consider factors like gaze tracking accuracy, ease of selection, and minimizing eye strain. We explored different layouts, iconography, and interaction models to ensure that our UI was not only functional but also user-friendly and accessible. The process taught us a great deal about the importance of design ergonomics and user experience in the context of non-traditional interaction methods.

Each of these learning experiences contributed significantly to our development journey, enriching our skills and understanding, and ultimately leading to the creation of a more refined and effective product.


