<%@ Page Title="" Language="C#" MasterPageFile="~/pharm.Master" AutoEventWireup="true" CodeBehind="PharmContent.aspx.cs" Inherits="Pharmacy.WebForm2" %>


<asp:Content ID="PharmContent" ContentPlaceHolderID="PharmContentPlaceHolder" runat="server">
    <div id="RawData"> 
        <div id = "RawContent" class="DataContent">
       <!-- <iframe id = "ifrmRawSearch"src="http://inside101/Mining/RawArchive/RawArchiveSearch.aspx"></iframe>
        -->
        </div>
    </div> 
    <div id="ArchiveData"> 
            <div id= "Tabs-Archive">
                <ul>
                    <li><a href="#OrderDetails">Order Details</a> </li>
                    <li><a href="#AggregateData">Summary</a> </li>
                    <li><a href="#RXC">RXC-Components</a> </li>
                    
                </ul>
                <div id="OrderDetails">
                <form id="archiveForm" action="">
                        <label for="msgStartDate">MessageDate Start: </label><input id ="msgStartDate" name ="Start" type ="text" class = "datepicker"/>
                        <label for="msgEndDate">MessageDate End: </label><input id ="msgEndDate" name ="End" type ="text" class = "datepicker"/>
                                <select id="ArchQuery">
                                    <option value="">Select...</option>
                                    <option value="Orders">Orders</option>
                                    
                                </select>                          
                        <br/>
                        
                </form>

                        <div id = "ArchiveContent" class="DataContent">
                        <hr/>
                        <div id="ArchivePager" ></div>
                        <table id="ArchiveTable" class="MMgrid"></table>
                        
                        </div>
                </div> 
                <div id="AggregateData">
                <form id="ArchStatsForm" action="">
                        <label for="AggMsgStart">MessageDate Start: </label><input id ="AggMsgStart" name = "Start" type ="text" class = "datepicker"/>
                        <label for="AggMsgEnd">MessageDate End: </label><input id ="AggMsgEnd" name="End" type ="text" class = "datepicker"/>                
                
                                 <label for = "ArchiveQuerySelect">Query: </label>
                                <select id="ArchiveQuerySelect">
                                    <option value="">Select...</option>
                                    <option value="OrderControls">OrderControls</option>
                                    <option value="DateTimes%">DateTimes%</option>
                                    <option value="MinMaxDates">Min/max Dates</option>
                                    <option value="Data%">Data%</option>
                                    <option value="NegativeDuration">NegativeDuration</option>
                                    <option value="DiffStartTimes">DiffStartTimes</option>
                                    <option value="MultipleNW">MultipleNW</option>
                                    <option value="MMNonUniqueRx#">MMNonUniqueRx#</option>
                                    <option value="SiteNonUniqueRx#">SiteNonUniqueRx#</option>
                                </select> 
                        </form>         
                        <div id = "AggContent" class="DataContent">
                        <hr/>
                        <table id="ArchStatsTable" class="MMgrid"></table>
                        <div id="ArchStatsPager"></div>   
                        </div>   
                                      
                </div>
              
                <div id="RXC">
                    <form id="RxcForm" action="">
                        <label for="msgStartDate">MessageDate Start: </label><input id ="RxcStart" name ="Start" type ="text" class = "datepicker"/>
                        <label for="msgEndDate">MessageDate End: </label><input id ="RxcEnd" name ="End" type ="text" class = "datepicker"/>
                                <select id="RxcSelect">
                                <option value="">Select</option>
                                     <option value="Components">Components</option>
                                    <option value="DistinctComponents">DistinctComponents</option>
                                </select>   
                      </form>                       
                        <br/>
                        <div id = "RxcContent" class="DataContent">
                            <hr/>
                            <table id="RxcTable" class="MMgrid"></table>
                             <div id="RxcPager" ></div>
                        </div>
                </div>

           </div>
    </div>
    <div id="DMSSData"> 
       <div id = "Tabs-Dmss">
                <ul>
                    <li><a href="#DmssOrderDetails">Order Details</a> </li>
                    <li><a href="#DmssAggregateData"  >PostLoad QA</a> </li>
                </ul>
                <div id= "DmssOrderDetails">
                <form id="d-OrderForm" action="">
                
                        <label for="d-msgStartDate">Startdate: </label><input id ="d-msgStartDate" type ="text" name="Start" class = "datepicker"/>
                        <label for="d-msgEndDate">EndDate: </label><input id ="d-msgEndDate" type ="text" name = "End" class = "datepicker"/>
                                 <label>Query: </label>
                                <select id="d-OrderSelect">
                                    <option value="">Select...</option>
                                    <option value="Orders-Rx">Orders/Prescriptions</option>
                                    <option value="SiteDrugs">SiteDrugs</option>
                                    <option value="AllSiteDrugs">AllSites-SiteDrugs</option>
                                    <option value="SiteRoutes">SiteRoutes</option>
                                    <option value="Frequencies">Frequencies</option>
                                    <option value="Condition">Condition</option>
                                    <option value="Priority">Priority</option>
                                    <option value="SiteDrugRoutes">SiteDrugRoutes</option>
                                    <option value="facilitySplit">FacilitySplit</option>
                                    <option value="LocationSplit">LocationSplit</option>
                                </select>  
               </form>
                        <div id = "d-Content" class="DataContent">
                        <hr/>
                            <!--<div id="LeftContent">
                               <table id="SiteList" class="MMgrid"></table>
                             </div >-->
                             
                            <div id ="RightContent"> 
                        <table id="d-OrderTable" class="MMgrid"></table>
                        <div id="d-OrdersPager" ></div>
                        <hr/>
                        <div id="2nd-d-Grid">
                         <table id="d-RxTable" class="MMgrid"></table>
                        <div id="d-Rxpager" ></div>
                        </div>
                        </div>           
                        </div>                
                </div>
                <div id= "DmssAggregateData">
                        <label for="d-AggmsgStart">MessageDate Start: </label><input id ="d-AggmsgStart" type ="text" class = "datepicker"/>
                        <label for="d-AggmsgEnd">MessageDate End: </label><input id ="d-AggmsgEnd" type ="text" class = "datepicker"/>
                                 <label>SearchField: </label>
                                <select id="d-AggSelect">
                                    <option value="">Select...</option>
                                    <option value="SiteTk">Site Tk</option>
                                    <option value="FacilityId">Facility Id</option>
                                </select>  
                         <label for="d-AggSearchValue">Search Value: </label><input id ="d-AggSearchValue" type ="text"/>
                        <div id = "d-OrderContent" class="DataContent">
                        <hr/>
                                                                                              
                        </div>                   
                </div>    
    
    </div>
    </div>

    <div id="Classes" class="DataContent">
        <form id="ClassForm" action="">
            <label for="ClassSelect">Query: </label>
            <select id="ClassSelect">
                <option value="">Select ...</option>
                <option value="PharmacyDrugs">PharmacyDrugs</option>
                <option value="PartialDrugs">PartialDrugs</option>
                <option value="Profiles">TreatmentProfiles</option>
                <option value="Classes">Classes</option>
            </select> 
        </form>
        <hr/>
         <table id="ClassTable" class="MMgrid"></table>
         <div id="ClassPager" ></div> 
    
    </div>
    <div id="AlertsReports"> Alerts/Reports Options</div>

</asp:Content>
