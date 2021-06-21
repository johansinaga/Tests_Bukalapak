# Tests_Bukalapak

## API Tests
- Install the latest SoapUI version via this link: https://www.soapui.org/downloads/soapui/
- Download both `API_Automation-soapui-project.xml` and `RunAPITest.bat`
- Update the `RunAPITest.bat` accordingly with the following format:


      CALL "{SoapUI_installation_folder}/bin/testrunner.bat" -a -j -f"{Directory_for_test_results}}" -I "{Location_Of_API_Automation-soapui-project.xml}"
- Run the batch file `RunAPITest.bat`





## Web and Mobile Tests
- Download latest Visual Studio
- Download `Web_Automation` folder build run the `Web_Automation.sln` solution file via Visual Studio
- Run test(s) from Test Explorer inside Visual Studio
