Agent.Faces
===========

A set of code which aids in prototyping watch faces for The Agent watch coming out in 2013.

Project Page here:
http://www.kickstarter.com/projects/secretlabs/agent-the-worlds-smartest-watch

Comments here:
http://www.kickstarter.com/projects/secretlabs/agent-the-worlds-smartest-watch/comments

Usage
=====

To create your own WatchFace:
# Download the source, make sure it builds
# Add a new class in the "Faces" folder
# On the source file for the class, and implement the interface Agent.Faces.IFace (there are a few samples you can learn from)
# Open Program.cs in the Agent.Faces project and change this line to call your new face:
# WatchFace.Start(new MyNewFace());


More
====
I have embedded three fonts, the two standard .NET Micro framework fonts (NinaB and small).  I also added "BootAntiquqNumbers" which only contains numbers and special characters (not letters); and is a larger font size.







