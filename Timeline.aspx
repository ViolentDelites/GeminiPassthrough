<%@ Page Language="C#" MasterPageFile="~/clwater/pages/masterpages/MasterMap.Master" AutoEventWireup="true" CodeBehind="Timeline.aspx.cs" Inherits="clwater_new.clwater.pages.Timeline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <svg class="bgBlue width-960px height-130px">
        <g>
            <text fill="white" y="40px" x="50px" font-size="20" font-weight="bold">TIMELINE</text>
            <text fill="#ffd18c" y="60px" x="50px" font-size="15" font-weight="bold">This timeline provides a chronological overview of key Camp Lejeune Historic Drinking Water events.</text>
            <text fill="#ffd18c" y="80px" x="50px" font-size="15" font-weight="bold">It is not intended to represent a comprehensive summary of events from 1941 to present. Scroll over</text>
            <text fill="#ffd18c" y="100px" x="50px" font-size="15" font-weight="bold">timeline entries in bold for additional information.</text>
        </g>
    </svg>
    <svg class="bgBlue width-960px height-1750px arial-font">
        <defs>
            <linearGradient id="BlueGradient">
                <stop offset="0" stop-color="white" stop-opacity="0" />
                <stop offset="1" stop-color="white" stop-opacity="1" />
            </linearGradient>
            <mask id="BlueMask">
                <rect width="400" height="1580" y="19px" x="260px" fill="url(#BlueGradient)" />
            </mask>
        </defs>
        <defs>
            <linearGradient id="FirstArrowGradient" x1="0%" y1="100%" x2="0%" y2="0%">
                <stop offset="0" stop-color="white" stop-opacity="0" />
                <stop offset="1" stop-color="white" stop-opacity="1" />
            </linearGradient>
            <mask id="FirstArrowMask">
                <polygon points="100,20 200,20 200,175 150,205 100,175" style="fill: url(#FirstArrowGradient);" />
                <polygon points="50,210 150,210 150,590 100,620 50,590" style="fill: url(#FirstArrowGradient);" />
                <polygon points="100,445 200,445 200,1520 150,1550 100,1520" style="fill: url(#FirstArrowGradient);" />
                <polygon points="50,625 150,625 150,1495 100,1525 50,1495" style="fill: url(#FirstArrowGradient);" />
            </mask>
        </defs>
        <defs>
            <filter id="filterShadow" x="0" y="0" width="200%" height="200%">
                <feOffset result="offOut" in="SourceAlpha" dx="20" dy="20" />
                <feGaussianBlur result="blurOut" in="OffOut" stdDeviation="10" />
                <feBlend in="SourceGraphic" in2="blurOut" mode="normal" />
            </filter>
        </defs>
        <g>
            <rect fill="#004a8d" width="40px" height="245px" y="20px" x="220px" />
            <text fill="white" x="230" y="80" writing-mode="tb" font-size="22" font-weight="bold">1941 - 1979</text>
        </g>
        <g>
            <rect fill="#004a8d" width="400px" height="5px" y="20px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="20px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="40px" x="270px" font-size="15">1941:</text>
            <text id="text1941hover1" fill="white" y="40px" x="310px" font-size="15" font-weight="bold">MCB Camp Lejeune</text>
            <text fill="white" y="40px" x="455px" font-size="15">is established. Hadnot Point housing is constructed</text>
            <text fill="white" y="55px" x="270px" font-size="15">and drinking water system began operation.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="60px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="60px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="80px" x="270px" font-size="15">1952:</text>
            <text fill="white" y="80px" x="310px" font-size="15">Tarawa Terrace housing is constructed and Tarawa Terrace drinking</text>
            <text fill="white" y="95px" x="270px" font-size="15">water system began operation.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="100px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="100px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="120px" x="270px" font-size="15">1953:</text>
            <text fill="white" y="120px" x="310px" font-size="15">Year ATSDR estimates Hadnot Point drinking water system was</text>
            <text fill="white" y="135px" x="270px" font-size="15">affected by chemicals.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="140px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="140px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="160px" x="270px" font-size="15">1957:</text>
            <text fill="white" y="160px" x="310px" font-size="15">Year ATSDR estimates Tarawa Terrace drinking water system was</text>
            <text fill="white" y="175px" x="270px" font-size="15">affected by chemicals.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="180px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="180px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="200px" x="270px" font-size="15">1972:</text>
            <text fill="white" y="200px" x="310px" font-size="15">Holcomb Boulevard drinking water system began operation.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="205px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="205px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="225px" x="270px" font-size="15">1979:</text>
            <text fill="white" y="225px" x="310px" font-size="15">EPA published drinking water standards for THMs, a by-product of drinking</text>
            <text fill="white" y="240px" x="270px" font-size="15">water disinfection, and suggested drinking water levels for TCE, a solvent often</text>
            <text fill="white" y="255px" x="270px" font-size="15">used for cleaning weapons and machinery.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="260px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="260px" x="260px" mask="url(#BlueMask)" />
        </g>
        <g>
            <rect fill="#004a8d" width="40px" height="305px" y="270px" x="220px" />
            <text fill="white" x="230" y="390" writing-mode="tb" font-size="22" font-weight="bold">1980s</text>
        </g>
        <g>
            <rect fill="#004a8d" width="400px" height="5px" y="270px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="270px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="290px" x="270px" font-size="15">1980:</text>
            <text fill="white" y="290px" x="310px" font-size="15">EPA published suggested drinking water levels for PCE, a solvent often</text>
            <text fill="white" y="305px" x="270px" font-size="15">used for dry cleaning.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="310px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="310px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="330px" x="270px" font-size="15">1980-1981:</text>
            <text fill="white" y="330px" x="350px" font-size="15">The base sampled drinking water for THMs and other chemicals</text>
            <text id="text1981hover1" fill="white" y="345px" x="270px" font-size="15" font-weight="bold">interfered with results.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="350px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="350px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="370px" x="270px" font-size="15">1982:</text>
            <text fill="white" y="370px" x="310px" font-size="15">Special</text>
            <text id="text1982hover1" fill="white" y="370px" x="362px" font-size="15" font-weight="bold">tap water testing</text>
            <text fill="white" y="370px" x="485px" font-size="15"> identified TCE and PCE as the chemicals</text>
            <text fill="white" y="385px" x="270px" font-size="15">interfering with results.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="390px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="390px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="410px" x="270px" font-size="15">1982-1984:</text>
            <text fill="white" y="410px" x="350px" font-size="15">The Navy initiated an environmental cleanup program to identify</text>
            <text fill="white" y="425px" x="270px" font-size="15">potentially contaminated sites at Camp Lejeune for further investigation. As part of</text>
            <text fill="white" y="440px" x="270px" font-size="15">this effort, drinking water wells near potentially contaminated sites were tested.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="445px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="445px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="465px" x="270px" font-size="15">1984-1985:</text>
            <text fill="white" y="465px" x="350px" font-size="15">Based on chemicals detected in drinking water wells near potentially</text>
            <text fill="white" y="480px" x="270px" font-size="15">contaminated sites, the Base initiated a comprehensive drinking water well testing</text>
            <text fill="white" y="495px" x="270px" font-size="15">effort. Ten wells were identified as being impacted and were removed from service</text>
            <text fill="white" y="510px" x="270px" font-size="15">the same day. The Base notified residents and workers through notices and</text>
            <text fill="white" y="525px" x="270px" font-size="15">newspaper articles.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="530px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="530px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="550px" x="270px" font-size="15">1987-1989:</text>
            <text fill="white" y="550px" x="350px" font-size="15">SDWA regulations for TCE, benzene, and vinyl chloride were published</text>
            <text fill="white" y="565px" x="270px" font-size="15">in the FR in 1987 and standards became effective and enforceable in 1989.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="570px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="570px" x="260px" mask="url(#BlueMask)" />
        </g>
        <g>
            <rect fill="#004a8d" width="40px" height="110px" y="580px" x="220px" />
            <text fill="white" x="230" y="605" writing-mode="tb" font-size="22" font-weight="bold">1990s</text>
        </g>
        <g>
            <rect fill="#004a8d" width="400px" height="5px" y="580px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="580px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="600px" x="270px" font-size="15">1991-1992:</text>
            <text fill="white" y="600px" x="350px" font-size="15">SDWA regulations for PCE were published in the FR in 1991 and</text>
            <text fill="white" y="615px" x="270px" font-size="15">standards became effective and enforceable in 1992.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="620px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="620px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="640px" x="270px" font-size="15">1991-1997:</text>
            <text fill="white" y="640px" x="350px" font-size="15">ATSDR conducted and published a PHA.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="645px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="645px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="665px" x="270px" font-size="15">1998:</text>
            <text fill="white" y="665px" x="310px" font-size="15">ATSDR published the results of its </text>
            <text id="text1998hover1" fill="white" y="665px" x="540px" font-size="15" font-weight="bold">“Volatile Organic Compounds in Drinking</text>
            <text id="text1998hover2" fill="white" y="680px" x="270px" font-size="15" font-weight="bold">Water and Adverse Pregnancy Outcomes Study.”</text>
            <a xlink:href="http://www.atsdr.cdc.gov/HS/lejeune/" target="_blank"><text fill="white" y="680px" x="625px" font-size="15" text-decoration="underline">http://www.atsdr.cdc.gov/HS/lejeune/</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="685px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="685px" x="260px" mask="url(#BlueMask)" />
        </g>
        <g>
            <rect fill="#004a8d" width="40px" height="330px" y="695px" x="220px" />
            <text fill="white" x="230" y="820" writing-mode="tb" font-size="22" font-weight="bold">2000s</text>
        </g>
        <g>
            <rect fill="#004a8d" width="400px" height="5px" y="695px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="695px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="715px" x="270px" font-size="15">2003-2005:</text>
            <text fill="white" y="715px" x="350px" font-size="15">EPA/DOJ criminal investigation concluded no SDWA violations and no</text>
            <text fill="white" y="730px" x="270px" font-size="15">conspiracy to conceal evidence.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="735px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="735px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="755px" x="270px" font-size="15">2004:</text>
            <text fill="white" y="755px" x="310px" font-size="15">Commandant of the Marine Corps established expert panel to examine</text>
            <text fill="white" y="770px" x="270px" font-size="15">past decision making. The panel reported no violations of law and no evidence</text>
            <text fill="white" y="785px" x="270px" font-size="15">of covering up information.</text>
            <a xlink:href="https://clnr.hqi.usmc.mil/clwater/content/documents/2004_CMC_Fact_Finding_report.pdf" target="_blank"><text fill="white" y="800px" x="270px" font-size="15" text-decoration="underline">https://clnr.hqi.usmc.mil/clwater/content/documents/2004_CMC_Fact_Finding_report.pdf</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="805px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="805px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="825px" x="270px" font-size="15">2005-2007:</text>
            <text fill="white" y="825px" x="350px" font-size="15">Government Accountability Office reviewed USMC actions and had no</text>
            <text fill="white" y="840px" x="270px" font-size="15">conclusions or recommendations.</text>
            <a xlink:href="https://www.gao.gov/new.items/d07276.pdf" target="_blank"><text fill="white" y="840px" x="495px" font-size="15" text-decoration="underline">https://www.gao.gov/new.items/d07276.pdf</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="845px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="845px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="865px" x="270px" font-size="15">2007:</text>
            <text fill="white" y="865px" x="310px" font-size="15">USMC launched notification and registration campaign for former residents</text>
            <text fill="white" y="880px" x="270px" font-size="15">to sign up for more information by telephone or internet.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="885px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="885px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="905px" x="270px" font-size="15">2007:</text>
            <text fill="white" y="905px" x="310px" font-size="15">ATSDR released its water modeling results for Tarawa Terrace and vicinity.</text>
            <a xlink:href="http://www.atsdr.cdc.gov/sites/lejeune/tarawaterrace.html" target="_blank"><text fill="white" y="920px" x="270px" font-size="15" text-decoration="underline">http://www.atsdr.cdc.gov/sites/lejeune/tarawaterrace.html</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="925px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="925px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="945px" x="270px" font-size="15">2009:</text>
            <text fill="white" y="945px" x="310px" font-size="15">ATSDR removed the PHA from its website and announced plans to</text>
            <text fill="white" y="960px" x="270px" font-size="15">re-evaluate the PHA drinking water portion when water modeling efforts are</text>
            <text fill="white" y="975px" x="270px" font-size="15">complete.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="980px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="980px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="1000px" x="270px" font-size="15">2009:</text>
            <text fill="white" y="1000px" x="310px" font-size="15">NRC released its </text>
            <text id="text2009hover1" fill="white" y="1000px" x="425px" font-size="15" font-weight="bold">“Contaminated Drinking Water at Camp Lejeune”</text>
            <text fill="white" y="1000px" x="778px" font-size="15">report.</text>
            <a xlink:href="http://dels.nas.edu/Report/Contaminated-Water-Supplies-Camp-Lejeune/12618" target="_blank"><text fill="white" y="1015px" x="270px" font-size="15" text-decoration="underline">http://dels.nas.edu/Report/Contaminated-Water-Supplies-Camp-Lejeune/12618</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="1020px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1020px" x="260px" mask="url(#BlueMask)" />
        </g>
        <g>
            <rect fill="#004a8d" width="40px" height="585px" y="1030px" x="220px" />
            <text fill="white" x="230" y="1250" writing-mode="tb" font-size="22" font-weight="bold">2010s</text>
            <polygon points="200,1605 280,1605 240,1700" class="blue-fill" />
        </g>
        <g>
            <rect fill="#004a8d" width="400px" height="5px" y="1030px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1030px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="1050px" x="270px" font-size="15">2012:</text>
            <text fill="white" y="1050px" x="310px" font-size="15">President Obama signed the “Honoring America’s Veterans and Caring for</text>
            <text fill="white" y="1065px" x="270px" font-size="15">Camp Lejeune Families Act of 2012” into law. The VA began providing health care</text>
            <text fill="white" y="1080px" x="270px" font-size="15">to eligible Camp Lejeune Veterans.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="1085px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1085px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="1105px" x="270px" font-size="15">2013:</text>
            <text fill="white" y="1105px" x="313px" font-size="15">ATSDR released its “Chapter A: Summary and Findings” water modeling</text>
            <text fill="white" y="1120px" x="270px" font-size="15">report for the Hadnot Point and Holcomb Boulevard water treatment plants and</text>
            <text fill="white" y="1135px" x="270px" font-size="15">vicinities at MCB Camp Lejeune, North Carolina. </text>
            <a xlink:href="https://www.atsdr.cdc.gov/sites/lejeune/hadnotpoint.html" target="_blank"><text fill="white" y="1150px" x="270px" font-size="15" text-decoration="underline">https://www.atsdr.cdc.gov/sites/lejeune/hadnotpoint.html</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="1155px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1155px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="1175px" x="270px" font-size="15">2013:</text>
            <text fill="white" y="1175px" x="313px" font-size="15">ATSDR’s </text>
            <text id="text2013hover1" fill="white" y="1175px" x="378px" font-size="15" font-weight="bold">“Exposure to Contaminated Drinking Water and Specific Birth</text>
            <text id="text2013hover2" fill="white" y="1190px" x="270px" font-size="15" font-weight="bold">Defects and Childhood Cancers at Marine Corps Base Camp Lejeune, North</text>
            <text id="text2013hover3" fill="white" y="1205px" x="270px" font-size="15" font-weight="bold">Carolina”</text>
            <text fill="white" y="1205px" x="340px" font-size="15">was published.</text>
            <a xlink:href="https://www.atsdr.cdc.gov/sites/lejeune/update.html" target="_blank"><text fill="white" y="1205px" x="443px" font-size="15" text-decoration="underline">https://www.atsdr.cdc.gov/sites/lejeune/update.html</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="1210px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1210px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="1230px" x="270px" font-size="15">2014:</text>
            <text fill="white" y="1230px" x="313px" font-size="15">ATSDR’s </text>
            <text id="text20141hover1" fill="white" y="1230px" x="378px" font-size="15" font-weight="bold">“Evaluation of mortality among Marines and Navy personnel</text>
            <text id="text20141hover2" fill="white" y="1245px" x="270px" font-size="15" font-weight="bold">exposed to contaminated drinking water at USMC Base Camp Lejeune: A</text>
            <text id="text20141hover3" fill="white" y="1260px" x="270px" font-size="15" font-weight="bold">retrospective cohort study”</text>
            <text fill="white" y="1260px" x="468px" font-size="15">was published.</text>
            <a xlink:href="https://www.atsdr.cdc.gov/sites/lejeune/mortalitystudy.html" target="_blank"><text fill="white" y="1275px" x="270px" font-size="15" text-decoration="underline">https://www.atsdr.cdc.gov/sites/lejeune/mortalitystudy.html</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="1280px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1280px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="1300px" x="270px" font-size="15">2014:</text>
            <text fill="white" y="1300px" x="313px" font-size="15">ATSDR’s </text>
            <text id="text20142hover1" fill="white" y="1300px" x="378px" font-size="15" font-weight="bold">“Mortality study of civilian employees exposed to contaminated</text>
            <text id="text20142hover2" fill="white" y="1315px" x="270px" font-size="15" font-weight="bold">drinking water at MCB Camp Lejeune: a retrospective cohort study” </text>
            <text fill="white" y="1315px" x="755px" font-size="15">was published.</text>
            <a xlink:href="https://www.atsdr.cdc.gov/sites/lejeune/civilianmortalitystudy.html" target="_blank"><text id="text20142hover4" fill="white" y="1330px" x="270px" font-size="15" text-decoration="underline">https://www.atsdr.cdc.gov/sites/lejeune/civilianmortalitystudy.html</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="1335px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1335px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="1355px" x="270px" font-size="15">2014:</text>
            <text fill="white" y="1355px" x="313px" font-size="15">ATSDR’s </text>
            <text id="text20143hover1" fill="white" y="1355px" x="378px" font-size="15" font-weight="bold">“Evaluation of contaminated drinking water and preterm</text>
            <text id="text20143hover2" fill="white" y="1370px" x="270px" font-size="15" font-weight="bold">birth, SGA, and birth weight at MCB Camp Lejeune, North Carolina: a cross-</text>
            <text id="text20143hover3" fill="white" y="1385px" x="270px" font-size="15" font-weight="bold">sectional study”</text>
            <text fill="white" y="1385px" x="390px" font-size="15">was published.</text>
            <a xlink:href="https://www.atsdr.cdc.gov/sites/lejeune/adversebirthoutcomesstudy.html" target="_blank"><text fill="white" y="1400px" x="270px" font-size="15" text-decoration="underline">https://www.atsdr.cdc.gov/sites/lejeune/adversebirthoutcomesstudy.html</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="1405px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1405px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="1425px" x="270px" font-size="15">2015:</text>
            <text fill="white" y="1425px" x="313px" font-size="15">ATSDR’s</text>
            <text id="text2015hover1" fill="white" y="1425px" x="378px" font-size="15" font-weight="bold">“Evaluation of contaminated drinking water and male breast</text>
            <text id="text2015hover2" fill="white" y="1440px" x="270px" font-size="15" font-weight="bold">cancer at MCB Camp Lejeune, North Carolina: a case control study”</text>
            <text fill="white" y="1440px" x="758px" font-size="15">was published.</text>
            <a xlink:href="https://www.atsdr.cdc.gov/sites/lejeune/malebreastcancerstudy.html" target="_blank"><text fill="white" y="1455px" x="270px" font-size="15" text-decoration="underline">https://www.atsdr.cdc.gov/sites/lejeune/malebreastcancerstudy.html</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="1460px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1460px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="1480px" x="270px" font-size="15">2017:</text>
            <text fill="white" y="1480px" x="313px" font-size="15">ATSDR’s</text>
            <text id="text2017hover1" fill="white" y="1480px" x="378px" font-size="15" font-weight="bold">“Camp Lejeune Drinking Water Public Health Assessment”</text>
            <text fill="white" y="1480px" x="803px" font-size="15"> was</text>
            <text fill="white" y="1495px" x="270px" font-size="15">published.</text>
            <a xlink:href="https://www.atsdr.cdc.gov/HAC/pha/MarineCorpsBaseCampLejeune/Camp_Lejeune_drinking_Water_PHA(final)_%201-20-2017_508.pdf" target="_blank"><text fill="white" y="1495px" x="343px" font-size="15" text-decoration="underline">https://www.atsdr.cdc.gov/HAC/pha/MarineCorpsBaseCampLejeune/</text></a>
            <a xlink:href="https://www.atsdr.cdc.gov/HAC/pha/MarineCorpsBaseCampLejeune/Camp_Lejeune_drinking_Water_PHA(final)_%201-20-2017_508.pdf" target="_blank"><text fill="white" y="1510px" x="270px" font-size="15" text-decoration="underline">Camp_Lejeune_drinking_Water_PHA(final)_%201-20-2017_508.pdf</text></a>
            <rect fill="#004a8d" width="400px" height="5px" y="1515px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1515px" x="260px" mask="url(#BlueMask)" />
            <text fill="#ffd18c" y="1535px" x="270px" font-size="15">2017:</text>
            <text fill="white" y="1535px" x="313px" font-size="15">VA issues presumptive service connection rule.</text>
            <rect fill="#004a8d" width="400px" height="5px" y="1540px" x="260px" />
            <rect fill="#6085c4" width="400px" height="5px" y="1540px" x="260px" mask="url(#BlueMask)" />
        </g>
        <g>
            <polygon points="200,1605 280,1605 240,1700" class="blue-fill" />
        </g>
        <g>
            <text fill="black" y="1600px" x="300px" font-size="12">ATSDR - Agency for Toxic Substances and Disease Registry</text>
            <text fill="black" y="1615px" x="300px" font-size="12">CLHDW - Camp Lejeune Historic Drinking Water</text>
            <text fill="black" y="1630px" x="300px" font-size="12">DOJ - Department of Justice</text>
            <text fill="black" y="1645px" x="300px" font-size="12">EPA - Environmental Protection Agency</text>
            <text fill="black" y="1660px" x="300px" font-size="12">FR - Federal Register</text>
            <text fill="black" y="1675px" x="300px" font-size="12">MBW - Mean Birth Weight</text>
            <text fill="black" y="1690px" x="300px" font-size="12">MCB - Marine Corps Base</text>
            <text fill="black" y="1705px" x="300px" font-size="12">NRC - National Research Council</text>
            <text fill="black" y="1720px" x="300px" font-size="12">PCE - Perchloroethylene</text>
        </g>
        <g>
            <text fill="black" y="1600px" x="650px" font-size="12">PHA - Public Health Assessment</text>
            <text fill="black" y="1615px" x="650px" font-size="12">SDWA - Safe Drinking Water Act</text>
            <text fill="black" y="1630px" x="650px" font-size="12">SGA - Small for Gestational Age</text>
            <text fill="black" y="1645px" x="650px" font-size="12">TCE - Trichloroethylene</text>
            <text fill="black" y="1660px" x="650px" font-size="12">THMs - Trihalomethanes</text>
            <text fill="black" y="1675px" x="650px" font-size="12">TLBW - Term Low Birth Weight</text>
            <text fill="black" y="1690px" x="650px" font-size="12">USMC - U.S. Marine Corps</text>
            <text fill="black" y="1705px" x="650px" font-size="12">VA - Department of Verterans Affairs</text>
            <text fill="black" y="1720px" x="650px" font-size="12">VOC - Volatile Organic Compounds</text>
        </g>
        <g>
            <polygon points="100,20 200,20 200,175 150,205 100,175" class="yellow-fill" />
            <polygon points="100,20 200,20 200,175 150,205 100,175" mask="url(#FirstArrowMask)" class="white-fill" />
            <text fill="#004a8d" y="60px" x="150px" font-size="15" font-weight="bold" text-anchor="middle">MCB</text>
            <text fill="#004a8d" y="80px" x="150px" font-size="15" font-weight="bold" text-anchor="middle">Camp</text>
            <text fill="#004a8d" y="100px" x="150px" font-size="15" font-weight="bold" text-anchor="middle">Lejeune</text>
            <text fill="#004a8d" y="120px" x="150px" font-size="15" font-weight="bold" text-anchor="middle">Drinking</text>
            <text fill="#004a8d" y="140px" x="150px" font-size="15" font-weight="bold" text-anchor="middle">Water</text>
            <text fill="#004a8d" y="160px" x="150px" font-size="15" font-weight="bold" text-anchor="middle">Systems</text>
        </g>
        <g>
            <polygon points="50,210 150,210 150,590 100,620 50,590" class="yellow-fill" />
            <polygon points="50,210 150,210 150,590 100,620 50,590" mask="url(#FirstArrowMask)" class="white-fill" />
            <text fill="#004a8d" y="300px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">Drinking</text>
            <text fill="#004a8d" y="320px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">Water</text>
            <text fill="#004a8d" y="340px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">System</text>
            <text fill="#004a8d" y="360px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">Requirements</text>
            <text fill="#004a8d" y="380px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">and</text>
            <text fill="#004a8d" y="400px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">Sampling</text>
            <text fill="#004a8d" y="420px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">Efforts</text>
        </g>
        <g>
            <polygon points="100,445 200,445 200,1520 150,1550 100,1520" class="yellow-fill" />
            <polygon points="100,445 200,445 200,1520 150,1550 100,1520" mask="url(#FirstArrowMask)" class="white-fill" />
            <text fill="#004a8d" y="525px" x="150px" font-size="15" font-weight="bold" text-anchor="middle">Notification</text>
            <text fill="#004a8d" y="545px" x="150px" font-size="15" font-weight="bold" text-anchor="middle">and</text>
            <text fill="#004a8d" y="565px" x="150px" font-size="15" font-weight="bold" text-anchor="middle">Outreach</text>
        </g>
        <g>
            <polygon points="50,625 150,625 150,1495 100,1525 50,1495" class="yellow-fill" />
            <polygon points="50,625 150,625 150,1495 100,1525 50,1495" mask="url(#FirstArrowMask)" class="white-fill" />
            <text fill="#004a8d" y="705px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">Scientific</text>
            <text fill="#004a8d" y="725px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">Studies</text>
            <text fill="#004a8d" y="745px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">and Health</text>
            <text fill="#004a8d" y="765px" x="100px" font-size="15" font-weight="bold" text-anchor="middle">Activities</text>
        </g>
        <g>
            <path id="rect1941" visibility="hidden" d="M700,40 L900,40 A20,20 0 0 1 920,60 L920,260 L720,260 A20,20 0 0 1 700,240 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text19411" visibility="hidden" x="710px" y="60px" fill="#004a8d" y="320px" x="100px" font-size="15">Since 1941, Camp Lejeune’s</text>
            <text id="text19412" visibility="hidden" x="710px" y="80px" fill="#004a8d" y="320px" x="100px" font-size="15">mission has been to prepare</text>
            <text id="text19413" visibility="hidden" x="710px" y="100px" fill="#004a8d" y="320px" x="100px" font-size="15">warfighters for deployment</text>
            <text id="text19414" visibility="hidden" x="710px" y="120px" fill="#004a8d" y="320px" x="100px" font-size="15">for combat and humanitarian</text>
            <text id="text19415" visibility="hidden" x="710px" y="140px" fill="#004a8d" y="320px" x="100px" font-size="15">missions abroad. The Base,</text>
            <text id="text19416" visibility="hidden" x="710px" y="160px" fill="#004a8d" y="320px" x="100px" font-size="15">which encompasses 236</text>
            <text id="text19417" visibility="hidden" x="710px" y="180px" fill="#004a8d" y="320px" x="100px" font-size="15">square miles (156,000 acres),</text>
            <text id="text19418" visibility="hidden" x="710px" y="200px" fill="#004a8d" y="320px" x="100px" font-size="15">provides housing, facilities,</text>
            <text id="text19419" visibility="hidden" x="710px" y="220px" fill="#004a8d" y="320px" x="100px" font-size="15">training lands, and logistical</text>
            <text id="text194110" visibility="hidden" x="710px" y="240px" fill="#004a8d" y="320px" x="100px" font-size="15">support for warfighters.</text>

            <path id="rect1981" visibility="hidden" d="M700,330 L900,330 A20,20 0 0 1 920,350 L920,390 L720,390 A20,20 0 0 1 700,370 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text19811" visibility="hidden" x="710px" y="350px" fill="#004a8d" y="320px" x="100px" font-size="15">The interference with THM</text>
            <text id="text19812" visibility="hidden" x="710px" y="370px" fill="#004a8d" y="320px" x="100px" font-size="15">results was inconsistent.</text>

            <path id="rect1982" visibility="hidden" d="M700,370 L900,370 A20,20 0 0 1 920,390 L920,470 L720,470 A20,20 0 0 1 700,450 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text19821" visibility="hidden" x="710px" y="390px" fill="#004a8d" y="320px" x="100px" font-size="15">The test results varied</text>
            <text id="text19822" visibility="hidden" x="710px" y="410px" fill="#004a8d" y="320px" x="100px" font-size="15">between drinking water</text>
            <text id="text19823" visibility="hidden" x="710px" y="430px" fill="#004a8d" y="320px" x="100px" font-size="15">samples collected at different</text>
            <text id="text19824" visibility="hidden" x="710px" y="450px" fill="#004a8d" y="320px" x="100px" font-size="15">times.</text>

            <path id="rect1998" visibility="hidden" d="M700,665 L900,665 A20,20 0 0 1 920,685 L920,825 L720,825 A20,20 0 0 1 700,805 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text19981" visibility="hidden" x="710px" y="685px" fill="#004a8d" y="320px" x="100px" font-size="15">The purpose of the study was</text>
            <text id="text19982" visibility="hidden" x="710px" y="705px" fill="#004a8d" y="320px" x="100px" font-size="15">to evaluate potential</text>
            <text id="text19983" visibility="hidden" x="710px" y="725px" fill="#004a8d" y="320px" x="100px" font-size="15">associations between</text>
            <text id="text19984" visibility="hidden" x="710px" y="745px" fill="#004a8d" y="320px" x="100px" font-size="15">exposures to contaminated</text>
            <text id="text19985" visibility="hidden" x="710px" y="765px" fill="#004a8d" y="320px" x="100px" font-size="15">drinking water at Camp</text>
            <text id="text19986" visibility="hidden" x="710px" y="785px" fill="#004a8d" y="320px" x="100px" font-size="15">Lejeune and adverse</text>
            <text id="text19987" visibility="hidden" x="710px" y="805px" fill="#004a8d" y="320px" x="100px" font-size="15">pregnancy outcomes.</text>

            <path id="rect2009" visibility="hidden" d="M700,1000 L900,1000 A20,20 0 0 1 920,1020 L920,1120 L720,1120 A20,20 0 0 1 700,1100 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text20091" visibility="hidden" x="710px" y="1020px" fill="#004a8d" y="320px" x="100px" font-size="15">The report consisted of a</text>
            <text id="text20092" visibility="hidden" x="710px" y="1040px" fill="#004a8d" y="320px" x="100px" font-size="15">review of scientific and</text>
            <text id="text20093" visibility="hidden" x="710px" y="1060px" fill="#004a8d" y="320px" x="100px" font-size="15">medical literature as well as</text>
            <text id="text20094" visibility="hidden" x="710px" y="1080px" fill="#004a8d" y="320px" x="100px" font-size="15">an assessment of current and</text>
            <text id="text20095" visibility="hidden" x="710px" y="1100px" fill="#004a8d" y="320px" x="100px" font-size="15">proposed ATSDR studies.</text>

            <path id="rect2013" visibility="hidden" d="M700,1175 L900,1175 A20,20 0 0 1 920,1195 L920,1355 L720,1355 A20,20 0 0 1 700,1335 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text20131" visibility="hidden" x="710px" y="1195px" fill="#004a8d" y="320px" x="100px" font-size="15">The purpose of this study was</text>
            <text id="text20132" visibility="hidden" x="710px" y="1215px" fill="#004a8d" y="320px" x="100px" font-size="15">to determine if maternal</text>
            <text id="text20133" visibility="hidden" x="710px" y="1235px" fill="#004a8d" y="320px" x="100px" font-size="15">exposures to the drinking</text>
            <text id="text20134" visibility="hidden" x="710px" y="1255px" fill="#004a8d" y="320px" x="100px" font-size="15">water contaminants at Camp</text>
            <text id="text20135" visibility="hidden" x="710px" y="1275px" fill="#004a8d" y="320px" x="100px" font-size="15">Lejeune increased the risk of</text>
            <text id="text20136" visibility="hidden" x="710px" y="1295px" fill="#004a8d" y="320px" x="100px" font-size="15">neural tube defects, oral clefts,</text>
            <text id="text20137" visibility="hidden" x="710px" y="1315px" fill="#004a8d" y="320px" x="100px" font-size="15">and childhood hematopoietic</text>
            <text id="text20138" visibility="hidden" x="710px" y="1335px" fill="#004a8d" y="320px" x="100px" font-size="15">cancers.</text>

            <path id="rect20141" visibility="hidden" d="M700,1230 L900,1230 A20,20 0 0 1 920,1250 L920,1410 L720,1410 A20,20 0 0 1 700,1390 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text201411" visibility="hidden" x="710px" y="1250px" fill="#004a8d" y="320px" x="100px" font-size="15">The purpose of this study was</text>
            <text id="text201412" visibility="hidden" x="710px" y="1270px" fill="#004a8d" y="320px" x="100px" font-size="15">to determine whether</text>
            <text id="text201413" visibility="hidden" x="710px" y="1290px" fill="#004a8d" y="320px" x="100px" font-size="15">exposures of Marine and Naval</text>
            <text id="text201414" visibility="hidden" x="710px" y="1310px" fill="#004a8d" y="320px" x="100px" font-size="15">personnel to contaminated</text>
            <text id="text201415" visibility="hidden" x="710px" y="1330px" fill="#004a8d" y="320px" x="100px" font-size="15">drinking water at Camp</text>
            <text id="text201416" visibility="hidden" x="710px" y="1350px" fill="#004a8d" y="320px" x="100px" font-size="15"> Lejeune increased risk of</text>
            <text id="text201417" visibility="hidden" x="710px" y="1370px" fill="#004a8d" y="320px" x="100px" font-size="15">mortality from cancers and</text>
            <text id="text201418" visibility="hidden" x="710px" y="1390px" fill="#004a8d" y="320px" x="100px" font-size="15">other chronic diseases.</text>

            <path id="rect20142" visibility="hidden" d="M700,1300 L900,1300 A20,20 0 0 1 920,1320 L920,1520 L720,1520 A20,20 0 0 1 700,1500 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text201421" visibility="hidden" x="710px" y="1320px" fill="#004a8d" y="320px" x="100px" font-size="15">The purpose of this study was</text>
            <text id="text201422" visibility="hidden" x="710px" y="1340px" fill="#004a8d" y="320px" x="100px" font-size="15">to determine whether</text>
            <text id="text201423" visibility="hidden" x="710px" y="1360px" fill="#004a8d" y="320px" x="100px" font-size="15">potential exposures to the</text>
            <text id="text201424" visibility="hidden" x="710px" y="1380px" fill="#004a8d" y="320px" x="100px" font-size="15">drinking water contaminants</text>
            <text id="text201425" visibility="hidden" x="710px" y="1400px" fill="#004a8d" y="320px" x="100px" font-size="15">at Camp Lejeune are</text>
            <text id="text201426" visibility="hidden" x="710px" y="1420px" fill="#004a8d" y="320px" x="100px" font-size="15">associated with increased risk</text>
            <text id="text201427" visibility="hidden" x="710px" y="1440px" fill="#004a8d" y="320px" x="100px" font-size="15">of death from specific cancers</text>
            <text id="text201428" visibility="hidden" x="710px" y="1460px" fill="#004a8d" y="320px" x="100px" font-size="15">and other chronic diseases</text>
            <text id="text201429" visibility="hidden" x="710px" y="1480px" fill="#004a8d" y="320px" x="100px" font-size="15">among civilian workers</text>
            <text id="text2014210" visibility="hidden" x="710px" y="1500px" fill="#004a8d" y="320px" x="100px" font-size="15">employed at the base.</text>

            <path id="rect20143" visibility="hidden" d="M700,1355 L900,1355 A20,20 0 0 1 920,1375 L920,1535 L720,1535 A20,20 0 0 1 700,1515 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text201431" visibility="hidden" x="710px" y="1375px" fill="#004a8d" y="320px" x="100px" font-size="15">The purpose of this study was</text>
            <text id="text201432" visibility="hidden" x="710px" y="1395px" fill="#004a8d" y="320px" x="100px" font-size="15">to evaluate associations</text>
            <text id="text201433" visibility="hidden" x="710px" y="1415px" fill="#004a8d" y="320px" x="100px" font-size="15">between residential prenatal</text>
            <text id="text201434" visibility="hidden" x="710px" y="1435px" fill="#004a8d" y="320px" x="100px" font-size="15">exposure to contaminated</text>
            <text id="text201435" visibility="hidden" x="710px" y="1455px" fill="#004a8d" y="320px" x="100px" font-size="15">drinking water at Camp</text>
            <text id="text201436" visibility="hidden" x="710px" y="1475px" fill="#004a8d" y="320px" x="100px" font-size="15">Lejeune between 1968 and</text>
            <text id="text201437" visibility="hidden" x="710px" y="1495px" fill="#004a8d" y="320px" x="100px" font-size="15">1985 and preterm birth, SGA,</text>
            <text id="text201438" visibility="hidden" x="710px" y="1515px" fill="#004a8d" y="320px" x="100px" font-size="15">TLBW, and MBW.</text>

            <path id="rect2015" visibility="hidden" d="M700,1425 L900,1425 A20,20 0 0 1 920,1445 L920,1565 L720,1565 A20,20 0 0 1 700,1545 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text20151" visibility="hidden" x="710px" y="1445px" fill="#004a8d" y="320px" x="100px" font-size="15">The purpose of this study was</text>
            <text id="text20152" visibility="hidden" x="710px" y="1465px" fill="#004a8d" y="320px" x="100px" font-size="15">to determine if Marines who</text>
            <text id="text20153" visibility="hidden" x="710px" y="1485px" fill="#004a8d" y="320px" x="100px" font-size="15">were exposed to contaminated</text>
            <text id="text20154" visibility="hidden" x="710px" y="1505px" fill="#004a8d" y="320px" x="100px" font-size="15">drinking water at Camp</text>
            <text id="text20155" visibility="hidden" x="710px" y="1525px" fill="#004a8d" y="320px" x="100px" font-size="15">Lejeune were more likely to</text>
            <text id="text20156" visibility="hidden" x="710px" y="1545px" fill="#004a8d" y="320px" x="100px" font-size="15">have male breast cancer.</text>

            <path id="rect2017" visibility="hidden" d="M700,1480 L900,1480 A20,20 0 0 1 920,1500 L920,1580 L720,1580 A20,20 0 0 1 700,1560 z" fill="#e4d0b5" filter="url(#filterShadow)" />
            <text id="text20171" visibility="hidden" x="710px" y="1500px" fill="#004a8d" y="320px" x="100px" font-size="15">The purpose of this study was</text>
            <text id="text20172" visibility="hidden" x="710px" y="1520px" fill="#004a8d" y="320px" x="100px" font-size="15">to update the drinking water</text>
            <text id="text20173" visibility="hidden" x="710px" y="1540px" fill="#004a8d" y="320px" x="100px" font-size="15">portion of the PHA that was</text>
            <text id="text20174" visibility="hidden" x="710px" y="1560px" fill="#004a8d" y="320px" x="100px" font-size="15">issued in 1997.</text>
        </g>
    </svg>

    <script type="text/javascript">
        $('#text1941hover1').mouseover(function (event) {
            Show1941();
        });
        $('#text1941hover1').mouseleave(function (event) {
            Hide1941();
        });
        $('#text1941hover2').mouseover(function (event) {
            Show1941();
        });
        $('#text1941hover2').mouseleave(function (event) {
            Hide1941();
        });
        $('#text1941hover3').mouseover(function (event) {
            Show1941();
        });
        $('#text1941hover3').mouseleave(function (event) {
            Hide1941();
        });

        $('#text1981hover1').mouseover(function (event) {
            Show1981();
        });
        $('#text1981hover1').mouseleave(function (event) {
            Hide1981();
        });
        $('#text1981hover2').mouseover(function (event) {
            Show1981();
        });
        $('#text1981hover2').mouseleave(function (event) {
            Hide1981();
        });
        $('#text1981hover3').mouseover(function (event) {
            Show1981();
        });
        $('#text1981hover3').mouseleave(function (event) {
            Hide1981();
        });

        $('#text1982hover1').mouseover(function (event) {
            Show1982();
        });
        $('#text1982hover1').mouseleave(function (event) {
            Hide1982();
        });
        $('#text1982hover2').mouseover(function (event) {
            Show1982();
        });
        $('#text1982hover2').mouseleave(function (event) {
            Hide1982();
        });
        $('#text1982hover3').mouseover(function (event) {
            Show1982();
        });
        $('#text1982hover3').mouseleave(function (event) {
            Hide1982();
        });

        $('#text1998hover1').mouseover(function (event) {
            Show1998();
        });
        $('#text1998hover1').mouseleave(function (event) {
            Hide1998();
        });
        $('#text1998hover2').mouseover(function (event) {
            Show1998();
        });
        $('#text1998hover2').mouseleave(function (event) {
            Hide1998();
        });
        $('#text1998hover3').mouseover(function (event) {
            Show1998();
        });
        $('#text1998hover3').mouseleave(function (event) {
            Hide1998();
        });

        $('#text2009hover1').mouseover(function (event) {
            Show2009();
        });
        $('#text2009hover1').mouseleave(function (event) {
            Hide2009();
        });
        $('#text2009hover2').mouseover(function (event) {
            Show2009();
        });
        $('#text2009hover2').mouseleave(function (event) {
            Hide2009();
        });
        $('#text2009hover3').mouseover(function (event) {
            Show2009();
        });
        $('#text2009hover3').mouseleave(function (event) {
            Hide2009();
        });

        $('#text2013hover1').mouseover(function (event) {
            Show2013();
        });
        $('#text2013hover1').mouseleave(function (event) {
            Hide2013();
        });
        $('#text2013hover2').mouseover(function (event) {
            Show2013();
        });
        $('#text2013hover2').mouseleave(function (event) {
            Hide2013();
        });
        $('#text2013hover3').mouseover(function (event) {
            Show2013();
        });
        $('#text2013hover3').mouseleave(function (event) {
            Hide2013();
        });
        $('#text2013hover4').mouseover(function (event) {
            Show2013();
        });
        $('#text2013hover4').mouseleave(function (event) {
            Hide2013();
        });

        $('#text20141hover1').mouseover(function (event) {
            Show20141();
        });
        $('#text20141hover1').mouseleave(function (event) {
            Hide20141();
        });
        $('#text20141hover2').mouseover(function (event) {
            Show20141();
        });
        $('#text20141hover2').mouseleave(function (event) {
            Hide20141();
        });
        $('#text20141hover3').mouseover(function (event) {
            Show20141();
        });
        $('#text20141hover3').mouseleave(function (event) {
            Hide20141();
        });
        $('#text20141hover4').mouseover(function (event) {
            Show20141();
        });
        $('#text20141hover4').mouseleave(function (event) {
            Hide20141();
        });
        $('#text20141hover5').mouseover(function (event) {
            Show20141();
        });
        $('#text20141hover5').mouseleave(function (event) {
            Hide20141();
        });

        $('#text20142hover1').mouseover(function (event) {
            Show20142();
        });
        $('#text20142hover1').mouseleave(function (event) {
            Hide20142();
        });
        $('#text20142hover2').mouseover(function (event) {
            Show20142();
        });
        $('#text20142hover2').mouseleave(function (event) {
            Hide20142();
        });
        $('#text20142hover3').mouseover(function (event) {
            Show20142();
        });
        $('#text20142hover3').mouseleave(function (event) {
            Hide20142();
        });
        $('#text20142hover4').mouseover(function (event) {
            Show20142();
        });
        $('#text20142hover4').mouseleave(function (event) {
            Hide20142();
        });

        $('#text20143hover1').mouseover(function (event) {
            Show20143();
        });
        $('#text20143hover1').mouseleave(function (event) {
            Hide20143();
        });
        $('#text20143hover2').mouseover(function (event) {
            Show20143();
        });
        $('#text20143hover2').mouseleave(function (event) {
            Hide20143();
        });
        $('#text20143hover3').mouseover(function (event) {
            Show20143();
        });
        $('#text20143hover3').mouseleave(function (event) {
            Hide20143();
        });
        $('#text20143hover4').mouseover(function (event) {
            Show20143();
        });
        $('#text20143hover4').mouseleave(function (event) {
            Hide20143();
        });
        $('#text20143hover5').mouseover(function (event) {
            Show20143();
        });
        $('#text20143hover5').mouseleave(function (event) {
            Hide20143();
        });

        $('#text2015hover1').mouseover(function (event) {
            Show2015();
        });
        $('#text2015hover1').mouseleave(function (event) {
            Hide2015();
        });
        $('#text2015hover2').mouseover(function (event) {
            Show2015();
        });
        $('#text2015hover2').mouseleave(function (event) {
            Hide2015();
        });
        $('#text2015hover3').mouseover(function (event) {
            Show2015();
        });
        $('#text2015hover3').mouseleave(function (event) {
            Hide2015();
        });
        $('#text2015hover4').mouseover(function (event) {
            Show2015();
        });
        $('#text2015hover4').mouseleave(function (event) {
            Hide2015();
        });

        $('#text2017hover1').mouseover(function (event) {
            Show2017();
        });
        $('#text2017hover1').mouseleave(function (event) {
            Hide2017();
        });
        $('#text2017hover2').mouseover(function (event) {
            Show2017();
        });
        $('#text2017hover2').mouseleave(function (event) {
            Hide2017();
        });
        $('#text2017hover3').mouseover(function (event) {
            Show2017();
        });
        $('#text2017hover3').mouseleave(function (event) {
            Hide2017();
        });
        $('#text2017hover4').mouseover(function (event) {
            Show2017();
        });
        $('#text2017hover4').mouseleave(function (event) {
            Hide2017();
        });

        function Show1941() {
            $('#rect1941').attr('visibility', 'visible');
            $('#text19411').attr('visibility', 'visible');
            $('#text19412').attr('visibility', 'visible');
            $('#text19413').attr('visibility', 'visible');
            $('#text19414').attr('visibility', 'visible');
            $('#text19415').attr('visibility', 'visible');
            $('#text19416').attr('visibility', 'visible');
            $('#text19417').attr('visibility', 'visible');
            $('#text19418').attr('visibility', 'visible');
            $('#text19419').attr('visibility', 'visible');
            $('#text194110').attr('visibility', 'visible');
        }
        function Hide1941() {
            $('#rect1941').attr('visibility', 'hidden');
            $('#text19411').attr('visibility', 'hidden');
            $('#text19412').attr('visibility', 'hidden');
            $('#text19413').attr('visibility', 'hidden');
            $('#text19414').attr('visibility', 'hidden');
            $('#text19415').attr('visibility', 'hidden');
            $('#text19416').attr('visibility', 'hidden');
            $('#text19417').attr('visibility', 'hidden');
            $('#text19418').attr('visibility', 'hidden');
            $('#text19419').attr('visibility', 'hidden');
            $('#text194110').attr('visibility', 'hidden');
        }

        function Show1981() {
            $('#rect1981').attr('visibility', 'visible');
            $('#text19811').attr('visibility', 'visible');
            $('#text19812').attr('visibility', 'visible');
        }
        function Hide1981() {
            $('#rect1981').attr('visibility', 'hidden');
            $('#text19811').attr('visibility', 'hidden');
            $('#text19812').attr('visibility', 'hidden');
        }

        function Show1982() {
            $('#rect1982').attr('visibility', 'visible');
            $('#text19821').attr('visibility', 'visible');
            $('#text19822').attr('visibility', 'visible');
            $('#text19823').attr('visibility', 'visible');
            $('#text19824').attr('visibility', 'visible');
        }
        function Hide1982() {
            $('#rect1982').attr('visibility', 'hidden');
            $('#text19821').attr('visibility', 'hidden');
            $('#text19822').attr('visibility', 'hidden');
            $('#text19823').attr('visibility', 'hidden');
            $('#text19824').attr('visibility', 'hidden');
        }

        function Show1998() {
            $('#rect1998').attr('visibility', 'visible');
            $('#text19981').attr('visibility', 'visible');
            $('#text19982').attr('visibility', 'visible');
            $('#text19983').attr('visibility', 'visible');
            $('#text19984').attr('visibility', 'visible');
            $('#text19985').attr('visibility', 'visible');
            $('#text19986').attr('visibility', 'visible');
            $('#text19987').attr('visibility', 'visible');
        }
        function Hide1998() {
            $('#rect1998').attr('visibility', 'hidden');
            $('#text19981').attr('visibility', 'hidden');
            $('#text19982').attr('visibility', 'hidden');
            $('#text19983').attr('visibility', 'hidden');
            $('#text19984').attr('visibility', 'hidden');
            $('#text19985').attr('visibility', 'hidden');
            $('#text19986').attr('visibility', 'hidden');
            $('#text19987').attr('visibility', 'hidden');
        }

        function Show2009() {
            $('#rect2009').attr('visibility', 'visible');
            $('#text20091').attr('visibility', 'visible');
            $('#text20092').attr('visibility', 'visible');
            $('#text20093').attr('visibility', 'visible');
            $('#text20094').attr('visibility', 'visible');
            $('#text20095').attr('visibility', 'visible');
        }

        function Hide2009() {
            $('#rect2009').attr('visibility', 'hidden');
            $('#text20091').attr('visibility', 'hidden');
            $('#text20092').attr('visibility', 'hidden');
            $('#text20093').attr('visibility', 'hidden');
            $('#text20094').attr('visibility', 'hidden');
            $('#text20095').attr('visibility', 'hidden');
        }

        function Show2013() {
            $('#rect2013').attr('visibility', 'visible');
            $('#text20131').attr('visibility', 'visible');
            $('#text20132').attr('visibility', 'visible');
            $('#text20133').attr('visibility', 'visible');
            $('#text20134').attr('visibility', 'visible');
            $('#text20135').attr('visibility', 'visible');
            $('#text20136').attr('visibility', 'visible');
            $('#text20137').attr('visibility', 'visible');
            $('#text20138').attr('visibility', 'visible');
        }

        function Hide2013() {
            $('#rect2013').attr('visibility', 'hidden');
            $('#text20131').attr('visibility', 'hidden');
            $('#text20132').attr('visibility', 'hidden');
            $('#text20133').attr('visibility', 'hidden');
            $('#text20134').attr('visibility', 'hidden');
            $('#text20135').attr('visibility', 'hidden');
            $('#text20136').attr('visibility', 'hidden');
            $('#text20137').attr('visibility', 'hidden');
            $('#text20138').attr('visibility', 'hidden');
        }

        function Show20141() {
            $('#rect20141').attr('visibility', 'visible');
            $('#text201411').attr('visibility', 'visible');
            $('#text201412').attr('visibility', 'visible');
            $('#text201413').attr('visibility', 'visible');
            $('#text201414').attr('visibility', 'visible');
            $('#text201415').attr('visibility', 'visible');
            $('#text201416').attr('visibility', 'visible');
            $('#text201417').attr('visibility', 'visible');
            $('#text201418').attr('visibility', 'visible');
        }

        function Hide20141() {
            $('#rect20141').attr('visibility', 'hidden');
            $('#text201411').attr('visibility', 'hidden');
            $('#text201412').attr('visibility', 'hidden');
            $('#text201413').attr('visibility', 'hidden');
            $('#text201414').attr('visibility', 'hidden');
            $('#text201415').attr('visibility', 'hidden');
            $('#text201416').attr('visibility', 'hidden');
            $('#text201417').attr('visibility', 'hidden');
            $('#text201418').attr('visibility', 'hidden');
        }

        function Show20142() {
            $('#rect20142').attr('visibility', 'visible');
            $('#text201421').attr('visibility', 'visible');
            $('#text201422').attr('visibility', 'visible');
            $('#text201423').attr('visibility', 'visible');
            $('#text201424').attr('visibility', 'visible');
            $('#text201425').attr('visibility', 'visible');
            $('#text201426').attr('visibility', 'visible');
            $('#text201427').attr('visibility', 'visible');
            $('#text201428').attr('visibility', 'visible');
            $('#text201429').attr('visibility', 'visible');
            $('#text2014210').attr('visibility', 'visible');
        }
        function Hide20142() {
            $('#rect20142').attr('visibility', 'hidden');
            $('#text201421').attr('visibility', 'hidden');
            $('#text201422').attr('visibility', 'hidden');
            $('#text201423').attr('visibility', 'hidden');
            $('#text201424').attr('visibility', 'hidden');
            $('#text201425').attr('visibility', 'hidden');
            $('#text201426').attr('visibility', 'hidden');
            $('#text201427').attr('visibility', 'hidden');
            $('#text201428').attr('visibility', 'hidden');
            $('#text201429').attr('visibility', 'hidden');
            $('#text2014210').attr('visibility', 'hidden');
        }

        function Show20143() {
            $('#rect20143').attr('visibility', 'visible');
            $('#text201431').attr('visibility', 'visible');
            $('#text201432').attr('visibility', 'visible');
            $('#text201433').attr('visibility', 'visible');
            $('#text201434').attr('visibility', 'visible');
            $('#text201435').attr('visibility', 'visible');
            $('#text201436').attr('visibility', 'visible');
            $('#text201437').attr('visibility', 'visible');
            $('#text201438').attr('visibility', 'visible');
        }
        function Hide20143() {
            $('#rect20143').attr('visibility', 'hidden');
            $('#text201431').attr('visibility', 'hidden');
            $('#text201432').attr('visibility', 'hidden');
            $('#text201433').attr('visibility', 'hidden');
            $('#text201434').attr('visibility', 'hidden');
            $('#text201435').attr('visibility', 'hidden');
            $('#text201436').attr('visibility', 'hidden');
            $('#text201437').attr('visibility', 'hidden');
            $('#text201438').attr('visibility', 'hidden');
        }

        function Show2015() {
            $('#rect2015').attr('visibility', 'visible');
            $('#text20151').attr('visibility', 'visible');
            $('#text20152').attr('visibility', 'visible');
            $('#text20153').attr('visibility', 'visible');
            $('#text20154').attr('visibility', 'visible');
            $('#text20155').attr('visibility', 'visible');
            $('#text20156').attr('visibility', 'visible');
        }
        function Hide2015() {
            $('#rect2015').attr('visibility', 'hidden');
            $('#text20151').attr('visibility', 'hidden');
            $('#text20152').attr('visibility', 'hidden');
            $('#text20153').attr('visibility', 'hidden');
            $('#text20154').attr('visibility', 'hidden');
            $('#text20155').attr('visibility', 'hidden');
            $('#text20156').attr('visibility', 'hidden');
        }

        function Show2017() {
            $('#rect2017').attr('visibility', 'visible');
            $('#text20171').attr('visibility', 'visible');
            $('#text20172').attr('visibility', 'visible');
            $('#text20173').attr('visibility', 'visible');
            $('#text20174').attr('visibility', 'visible');
        }
        function Hide2017() {
            $('#rect2017').attr('visibility', 'hidden');
            $('#text20171').attr('visibility', 'hidden');
            $('#text20172').attr('visibility', 'hidden');
            $('#text20173').attr('visibility', 'hidden');
            $('#text20174').attr('visibility', 'hidden');
        }
    </script>
</asp:Content>
