Agent.Faces
===========

A set of code which aids in prototyping watch faces for The Agent watch coming out in 2013.

Project Page here:
http://www.kickstarter.com/projects/secretlabs/agent-the-worlds-smartest-watch

Comments here:
http://www.kickstarter.com/projects/secretlabs/agent-the-worlds-smartest-watch/comments

Usage
=====

You have two options to control painting of the face of the watch.

1. OnPaint event.  

static void watchFace_OnPaint(WatchFace face, Device device){
//place your custom face painting in this method

}

static void watchFace_OnSetupCompleted(WatchFace face, Device device) {
//this will fire once per app start, before any face painting
//example use would be to control the border like so...
device.Border = new Border() { Thickness = 1, FooterHeight = device.NinaBFont.Height + 2, HeaderHeight = 10 };     

}

More
====
I have embedded three fonts, the two standard .NET Micro framework fonts (NinaB and small).  I also added "BootAntiquqNumbers" which only contains numbers and special characters (not letters); and is a larger font size.







