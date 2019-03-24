# kaazingtest
Simple SSE sample using kaazing nuget package showing ERROR

# Updates from Kaazing

The existing Kaazing client libraries don't currently support HTTP/2 for Server Sent Events.  We have updated this sample
to use the EvtSource package (currently compiled locally as it required minor changes) and HTTP/2 support via the WinHttpHandler package from nuget.

### First, grab and build EvtSource:

* Download the `EvtSource` package from github into your dev tree: https://github.com/kaazing/EvtSource.git
    * We will be submitting our changes back as PR's to the EvtSource authors
* Under "File/Open" select "Project/Solution" to open the .sln file within Visual Studio
    * We used Visual Studio 2019 Preview
* Under "Project", select "Manage NuGet packages"
    * Select "Browse", enter "WinHttpHandler"
    * Select "Install"
* Build
    * By default, .dll's are built for the various versions of .NET
    * Take note of the location of the .NET standard 2.0 .dll location listed

### Then, grab and build the sample app kaazingtest:

* Download the "updated" `kaazingtest` sample from: https://github.com/kaazing/kaazingtest
    * If you'd like us to push our changes back to you via a pull request, let us know
* Under "File/Open" select "Project/Solution" to open the .sln file within Visual Studio
* Under "Project", select "Manage NuGet packages"
    * Select "Browse", enter "WinHttpHandler"
    * Select "Install"
* May need to add a reference to the EvtSource .dll built earlier
    * The updated .csproj file contains a reference to the .NET Standard 2.0 EvtSource.dll assuming that EvtSource and kaazingtest we in the same directory at the same level.
    * If the reference is incorrect, remove the existing EvtSource reference (right click on EvtSource under Reference in Solutions Explorer)
    * Under "Project", select "Add Reference" (or right click in Solutions Explorer and "Add Reference")
    * Browse to the .NET standard 2.0 .dll location (...bin\Debug\netstandard2.0\EvtSource.dll)
* The references to the kaazing standard client library can be removed
* Build, run.
