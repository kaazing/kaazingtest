# kaazingtest
Simple SSE sample using kaazing nuget package showing ERROR

# Updates from Kaazing

The existing Kaazing client libraries don't currently support HTTP/2 for Server Sent Events.  

We have updated this sample to use two packages from NuGet:
- 3v.EvtSource package (version 1.1.1 or better)
- WinHttpHandler package (version 4.6.0 or better)
    - Allows application to specify to use HTTP/2 client

We've tested this updated sample with .NET Core 2.0 and .NET Framework 4.7.2 Console applications.  Built using Visual Studio 2019 on Windows 10.

### Insructions to Build/Run:

* Grab the "updated" `kaazingtest` sample from: https://github.com/kaazing/kaazingtest
* Under "File/Open" select "Project/Solution" to open the .sln file within Visual Studio
* Under "Build", select "Build Solution"
* Run

