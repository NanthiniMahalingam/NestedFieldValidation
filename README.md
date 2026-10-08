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
| Test commit | [`dde733e3d352f079c0d11090f50afe2c42c4f7e7`](https://github.com/NanthiniMahalingam/NestedFieldValidation/tree/dde733e3d352f079c0d11090f50afe2c42c4f7e7) |

The required SDK is pinned by `NestedValidation/global.json`.

## Prerequisites

- Install .NET SDK `11.0.100-rc.1.26425.128`.

## Create the sample

The sample was created as a statically rendered Blazor Web App:

```powershell
dotnet new blazor -o NestedValidation --interactivity None
```

The files in this repository contain the scenario-specific nested model,
validation registration, and form changes applied to that generated project.
The checked-in `NestedValidation/global.json` preserves the SDK used for the
test.

## Restore and build

Run all commands from the `NestedValidation` directory so that the SDK version
in `global.json` is applied:

```powershell
cd NestedValidation
dotnet --version
dotnet restore
dotnet build
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

## Verify nested-field validation manually

Open the browser's developer tools before testing, select the **Network** tab,
and clear existing requests. Run these three checks in order:

1. **Ordinary empty submit**
   - Leave **Shipping street** empty.
   - Select **Place order**.
   - Verify that **Street is required.** appears beside the field.
   - Verify that the Network tab contains no POST for this action.
2. **Empty submit with browser validation bypassed**
   - Clear the Network tab and leave **Shipping street** empty.
   - Select **Place order without browser validation**.
   - Verify that a POST is sent and that the server-returned HTML contains
     **Street is required.** for `Model.ShippingAddress.Street`.
   - Verify that the same message appears beside the field and that
     **The order is valid and has been submitted.** is not displayed.
3. **Corrected ordinary submit**
   - Clear the Network tab and enter a street, such as `123 Main Street`.
   - Select **Place order**.
   - Verify that a POST is sent and that
     **The order is valid and has been submitted.** appears.

The two invalid checks must display the same field message:
**Street is required.** Only the corrected submit must display the order
confirmation.

## Evidence revisions

The tested source and complete committed evidence revision is
`dde733e3d352f079c0d11090f50afe2c42c4f7e7`.

The revision includes the following supplemental evidence:

- [Corrected valid POST wire evidence](Evidence/CorrectedValidPostWireEvidence.json)
  contains privacy-redacted request headers, payload, complete response headers
  and body, the generated nested browser-validation rule, and the valid-order
  confirmation.
- [Corrected valid POST confirmation](Evidence/CorrectedValidPostConfirmation.png)
  shows the submitted street and the returned confirmation.
