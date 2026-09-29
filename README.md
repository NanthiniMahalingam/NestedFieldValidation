# Nested field validation

This repository is a minimal ASP.NET Core Razor Components application that
demonstrates validation of a field on a nested model. Submitting the form with
an empty shipping street displays the `Street is required.` validation message.

## Build under test

| Component | Version |
| --- | --- |
| .NET runtime / ASP.NET Core runtime | `11.0.0-rc.1.26425.128` |
| .NET SDK | `11.0.100-rc.1.26425.128` |
| Target framework | `net11.0` |

The required SDK is pinned by `NestedValidation/global.json`.

## Prerequisites

- Install .NET SDK `11.0.100-rc.1.26425.128`.

## Restore and build

Run all commands from the `NestedValidation` directory so that the SDK version
in `global.json` is applied:

```powershell
cd NestedValidation
dotnet --version
dotnet restore
```

The `dotnet --version` command must print `11.0.100-rc.1.26425.128`.


## Run each configuration

The project provides `http` launch profiles. Stop a running
configuration with <kbd>Ctrl</kbd>+<kbd>C</kbd> before starting another one.

### Debug over HTTP

```powershell
dotnet run --configuration Debug --launch-profile http
```

Open <http://localhost:5292>.

## Verify nested-field validation

Repeat these steps for each configuration covered above:

1. Leave **Shipping street** empty.
2. Select **Place order without browser validation**.
3. Verify that **Street is required.** appears and that the success message is
   not displayed.
4. Enter a value in **Shipping street** and select **Place order**.
5. Verify that **The order is valid and has been submitted.** appears.
