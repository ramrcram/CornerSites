<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="NewDataSet/Table">
      <div>
        <div>
          <table>
            <tr>
              <td>
                Service Pack name : 
              </td>
              <td>
                <xsl:value-of select ="ServicePackName"/>
              </td>
            </tr>
            <tr>
              <td>
                Subscription Date :
              </td>
              <td>
                <xsl:value-of select ="SubscriptionDate"/>
              </td>
            </tr>
            <tr>
              <td>
                Subscription Expiry Date:
              </td>
              <td>
                <xsl:value-of select ="subscriptionExpiryDate"/>
              </td>
            </tr>
            <tr>
              <td>
                Total Count : 
              </td>
              <td>
                <xsl:value-of select ="TotalCount"/>
              </td>
            </tr>
            <tr>
              <td>
                Remaining Count :
              </td>
              <td>
                <xsl:value-of select ="RemainingCount"/>
              </td>
            </tr>
            <tr>
              <td>
                Used Count :
              </td>
              <td>
                <xsl:value-of select ="UsedCount"/>
              </td>
            </tr>
            <tr>
              <td>
                Validity Days:
              </td>
              <td>
                <xsl:value-of select ="ValidityDays"/>
              </td>
            </tr>
          </table>
        </div>
      </div>
    </xsl:template>
</xsl:stylesheet>
