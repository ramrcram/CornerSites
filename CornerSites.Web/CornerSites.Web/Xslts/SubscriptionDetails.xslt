<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes"/>
  <xsl:template match="NewDataSet">
    <xsl:for-each select="Table">
      <div style="width: 100%; border: solid 5px #FFFFFF">
        <div style="padding-bottom: 15px">
          <b>
            <input type="radio" name="ShortName" >
              <xsl:attribute name="value">
                <xsl:value-of select="ShortName"/>
              </xsl:attribute>
              <xsl:attribute name="onclick">
                javascript:return AddSubscription('<xsl:value-of select="TypeID"/>','<xsl:value-of select ="AdType"/>');
              </xsl:attribute>
            </input>
          </b>
        </div>
        <div style="clear: both">
        </div>
        <div style="width: 35%; float: left; padding-bottom: 15px">
          <div>
            <xsl:value-of select="TypeDescription"/>
          </div>
          <div style="clear: both">
          </div>
          <div>
            <xsl:value-of select="ValidDays"/>
          </div>
          <div style="clear: both">
          </div>
          <div>
            <xsl:value-of select="TargetPage"/>
          </div>
        </div>
        <div style="clear: both">
        </div>
        <div style="width: 35%;float: left; padding-bottom: 15px">
          <xsl:value-of select="TargetPage"/>
        </div>
        <div style="width: 35%; float: right; padding-bottom: 15px">
          <div>
            <img src="url" alt="some_text" >
              <xsl:attribute name="src" >
                <xsl:value-of select="SampleImage"/>
              </xsl:attribute>
            </img>
          </div>
        </div>
        <div style="clear: both">
        </div>
      </div>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>
