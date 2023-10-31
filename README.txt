---- KAYAHOME PROJECT

-- Create DB Context (Migrations)
add-migration KayaHomeDB-v1

-- Add DB Context to SQL server
update-database

-- Web.Config
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
 <system.webServer>
    <rewrite>
        <rewriteMaps>
            <rewriteMap name="^(.*)$" />
        </rewriteMaps>
        <rules>
            <rule name="Angular Route" stopProcessing="true">
                <match url="^(.*)$" />
                <conditions logicalGrouping="MatchAll">
                    <add input="{REQUEST_URI}" pattern="/api(.*)$" negate="true" />
                    <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
                </conditions>
                <action type="Rewrite" url="/index.html" />
            </rule>
        </rules>
    </rewrite>
    <security>
        <authorization>
            <remove users="*" roles="" verbs="" />
            <add accessType="Allow" users="?" />
        </authorization>
    </security>
 </system.webServer>
</configuration>