<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="NewDataSet">
      <xsl:for-each select="Table">
        <xsl:variable name="AgentID" >
          <xsl:value-of select="AgentID"/>
        </xsl:variable>
          <div>
            <xsl:value-of select="AgentName"/>
            <br></br>
            <xsl:value-of select="AgentOrganisationName"/>           
          </div>
          <div>
            <xsl:value-of select="AboutAgent"/>
          </div>
          <div>
            <div style="float: left ;padding-bottom:15px">
              <input type="button" id="btnContactsAgent_{$AgentID}" onclick="javascript:return ViewContactAgent();" value="View Contact Details" />
            </div>
            <div style="float: left ;padding-bottom:15px">
              <input type="button" id="btnEmailAgent_{$AgentID}" value="Email" />
            </div>
          </div>
      </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
