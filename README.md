[![Nuget](https://img.shields.io/nuget/dt/buildergenerator)](https://www.nuget.org/packages/BuilderGenerator/)
[![GitHub](https://img.shields.io/github/license/melgrubb/buildergenerator)](https://opensource.org/licenses/MIT)
[![GitHub issues](https://img.shields.io/github/issues/melgrubb/buildergenerator)](https://github.com/MelGrubb/BuilderGenerator/issues)
[![CI](https://github.com/MelGrubb/BuilderGenerator/actions/workflows/ci.yml/badge.svg)](https://github.com/MelGrubb/BuilderGenerator/actions/workflows/ci.yml)
[![Discord](https://img.shields.io/discord/813785114722697258?logo=discord&logoColor=white)](https://discord.com/channels/813785114722697258/1099524153436012694)

# This Fork #

This fork exists to demonstrate a workaround for the famous longstanding issue "Visual Studio does not refresh my source generator that I have just edited, I cannot see changes I just made reflected in Intellisense". In short, if you have both your source generator project and your dependant client project in the same solution, the initial version of the source generator used for intellisense in the client project will remain, no matter what changes/cleans/rebuilds/reloads you do to the generator project. Ultimately, restarting VS is your only sure option here.
Interestingly, while the intellisense version of your analyzer is 'stuck', it seems that the source-gen files exported via the *EmitCompilerGeneratedFiles* option are always up to date. The hack presented here is simply and exploitation of this - if the files are up to date, then make them part of your build, and sprinkle a couple dirty tricks to avoid name clashes against the in-memory versions of the same classes. Because these are just normal source files, they will always be picked up afresh by intellisense, no need to do any further magic here.

In a nutshell:

1. Use *EmitCompilerGeneratedFiles* and *CompilerGeneratedFilesOutputPath* to output generated files (with regards to source control it's probably good if you gitinore them, but it's up to you)
2. Put any 'API' parts of your generator, like attributes etc., as normal files in a dedicated project. These files need to the compiler beforehand, so that we can always get good compilation to boot. *TODO: check this*
3. Make all your generated class use a fairly unique namespace that will not be easily/accidentaly discoverable by the client.
4. After all the files are emitted, have post-build event to go through the files and fix the namespace to the one expected by the client.
5. Files get overwritten when emitting, so any continuously existing files will be up to date. Handle any leftover files that don't get generated anymore by deleting *non-recently modified* files in the post-build event.
6. This should now let you see the changes to your generator propagate to your client project without issues. As an added bonus, you have all your generated code in the plain sight, where you can inspect it and place breakpoints for debugging.

Finally, please note that this is not meant to be a 'production use' solution, it's only here to make your life as source generator author easier, and to help you get more immediate feedback on your work. Oh, and unit tests, don't forget unit tests even if you can now easily 'test by hand' - the original project shows very well how do set them up.

Please let me know if you find improvements to this glorious hack!

Now, about the original project:

# Builder Generator #

This is a .Net Source Generator designed to add "Builders" to your projects. [Builders](https://en.wikipedia.org/wiki/Builder_pattern) are an object creation pattern, similar to the [Object Mother](https://martinfowler.com/bliki/ObjectMother.html) pattern. Object Mothers and Builders are most commonly used to create objects for testing, but they can be used anywhere you want "canned" objects.

For more complete documentation, please see the [documentation site](https://melgrubb.github.io/BuilderGenerator/) or the raw [documentation source](https://github.com/MelGrubb/BuilderGenerator/blob/main/docs/index.md).

## Known Issues ##

This project has moved to the .Net 6 version of source generators, which unfortuntely means that it's incompatible with Visual Studio 2019. It's also breaking the GitHub build pipeline at the moment. It all seems to work just fine in VS2022 though. If you're stuck on .Net 5 and VS2019, you can always use the v1.x series, although its usage is different.

## Installation ##

BuilderGenerator is installed as an analyzer via NuGet package (https://www.nuget.org/packages/BuilderGenerator/). You can find it through the "Manage NuGet Packages" dialog in Visual Studio, or from the command line.

```ps
Install-Package BuilderGenerator
```

## Usage ##

After installation, create a partial class to define your builder in. Decorate it with the ```BuilderFor``` attribute, specifying the type of class that the builder is meant to build (e.g. ```[BuilderFor(typeof(Foo))]```. Define any factory and helper methods in this partial class. Meanwhile, another partial class definition will be auto-generated which contains all the "boring" parts such as the backing fields and "with" methods.

## Version History ##
- v2.3.0
    - Major caching and performance improvements
    - Internal code cleanup
    - Conversion of templates to embedded resources

- v2.2.0
  - Changed generated file extension to .g.cs

- v2.0.7
  - Fixed #13, NetStandard2.0 compatibility

- v2.0.6
  - Fixed #12, Generated files now marked with auth-generated header

- v2.0.5
  - Fixed #14, duplicate properties

- v2.0.3
  - Attempting to fix NuGet packaging problems

- v2.0.2
  - Setters for base class properties rendering properly

- v2.0.1
  - Improved error handling

- v2.0.0
  - Updated to .Net 6 and IIncrementalGenerator (See note above about incompatibility with VS2019)
  - Changed usage pattern from marking target classes with attributes to marking partial builder classes

- v1.2
  - Solution reorganization
  - Version number synchronization
  - Automated build pipeline

- v1.0
  - First major release

- v0.5
  - Public beta
  - Working NuGet package
  - Customizable templates

## Roadmap ##

- Read-only collection support in default templates
- Attribute-less generation of partial classes
- Completed documentation
- Unit tests for generation components

## Attributions ##

The BuilderGenerator logo includes [tools](https://thenounproject.com/term/tools/11192) by John Caserta from the Noun Project.
