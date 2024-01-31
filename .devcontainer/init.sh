#!/bin/bash

echo 'export PATH=$HOME/.dotnet/tools:$PATH' >> ~/.zshrc

dotnet tool install --global dotnet-ef
dotnet tool install Nuke.GlobalTool --global

pnpm install