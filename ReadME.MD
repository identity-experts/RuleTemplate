# RuleTemplate

Template for creating Rule Extension projects for (MIIS/ILM)/FIM/MIM directly within Visual Studio

## Overview

This library is used to create a new project type in Visual Studio that enables you to create Rule Extension projects directly 
rather than needing to use the FIM/MIM console.

This library is broken down into different sections, making it easier to locate each piece of code and steps through each of the 
key areas of code in numerical order to help guide implementation from construction through to flow rules.

Recommended usage is to break down your flow logic into "single-purpose" methods and then link these together via the parent methods.

For example, the MapAttributesForImport method shouldn't contain any actual flow rules but can be used as an internal "router" to call the
required method for each flow rule. This has advantages of improving readability and locatability of code, and adheres to the Single-function principle.

## Using the library

* Create a local copy by downloading / pulling mvtemplate
* Make sure that package definitions are upto date via nuget
* On the Visual Studio "File" Menu, select "Export Template"
* ensure that "project template" is selected and click "next"
* click "finish"

Create a new project, and the new template should be visible in the "C#" section.
