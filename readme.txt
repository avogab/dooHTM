===============
The dooHTM is a c# application that permits a first glance at Numenta's Hierarchical
Temporal Memory (HTM) new algorithms using very simple generated motion images.

The application make use of the Emgu CV library, the wrapper to the OpenCV image library.
The library's files are included in the project and automatically copied to the
bin\Debug directory during the build phase.

The source code comments are practically totally get from Numenta's paper, nevertheless I hope the code
is tidy enough to allow a fast understanding.

The application is in a early development and I do not guarantee that the source code respects
precisely the Numenta's algorithms and his intent.

===============
Prerequisites
===============
.NET Framework 3.5

===============
Quick start
===============
- click on 'Image desktop' button
- set the parameters on Environment form
- set the parameters on HTMBuilder form
- click on 'Initialize' button
- push 'Step' button or 'Loop' button.

or

- click on 'Data desktop' button
- Load a binary text file
- set the parameters on HTMBuilder form
- click on 'Initialize' button
- push 'Step' button or 'Loop' button.


===============
Gabriele Avolio