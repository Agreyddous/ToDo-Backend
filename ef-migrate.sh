#!/bin/bash

dotnet.exe ef migrations add $1 -s ./ToDo.API/ -p ./ToDo.Domain.Infra/