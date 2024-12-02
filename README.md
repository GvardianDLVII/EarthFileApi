# EarthFileApi
API for reading and writing of Earth 2150 files.

## Features
Currently the package allows reading and writing of level LND and MIS files, as well as profile .DAT files. For that, you should use `Ieo.EarthFileApi.Files.EarthFileReader` and `Ieo.EarthFileApi.Files.EarthFileWriter`. You can see some usage examples in sorces of Tests project

## FileReaderSample
This repo provides a sample application that allows the following conversions:
- profile file to JSON (`.dat` to `.dat.json`)
- level files to JSON (`.lnd` to `.lnd.json` and `.mis` to `.mis.json`)
- scripts file to JSON (`.ecoMP` to `.ecoMP.json` + `.ecoMP.eil.json` file with deassembly that can make compiled scripts understandable)
- language files to JSON (`.lan` to `.lan.json`)

The JSON format is human readable (especially when used with tools such as https://jsoneditoronline.org/). In case of some fiels, the tool allows conversion back to game file format (which means you can edit json and save it back)
- profile file (`.dat.json` to `.dat`)
- language file (`.lan.json` to `.dat`)

Usage is very simple - just drag and drop one of supported files over the exe. You will need .NET 8.0 runtime to execute the tool.
