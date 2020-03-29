[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Base64.svg)](https://www.nuget.org/packages/ByteDev.Base64)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Base64/blob/master/LICENSE)

# ByteDev.Base64

.NET Standard library for handling base64 strings.

## Installation

ByteDev.Base64 has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Base64 is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Base64`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Base64/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Base64/blob/master/docs/RELEASE-NOTES.md).

## Code

The repo can be cloned from git bash:

`git clone https://github.com/ByteDev/ByteDev.Base64`

## Usage

The package contains the following methods:

- Base64Encoder
  - IsBase64Encoded
  - CalcBase64EncodedSize
  - ConvertToBase64
  - ConvertFromBase64
- Base64Serializer (IBase64Serializer)
  - Serialize
  - Deserialize
- StringExtensions
  - IsBase64
