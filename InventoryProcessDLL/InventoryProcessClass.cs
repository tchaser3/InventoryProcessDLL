/* Title:           Inventory Process Class
 * Date:            7/24/20
 * Author:          Terry Holmes
 * 
 * Description:     This is used for the new inventory Process */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace InventoryProcessDLL
{
    public class InventoryProcessClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        WIPInventoryDataSet aWIPInventoryDataSet;
        WIPInventoryDataSetTableAdapters.wipinventoryTableAdapter aWIPInventoryTableAdapter;

        InsertWIPInventoryEntryTableAdapters.QueriesTableAdapter aInsertWIPInventoryTableAdapter;

        UpdateWIPInventoryEntryTableAdapters.QueriesTableAdapter aUpdateWIPInventoryTableAdapter;

        FindWIPInventoryPartWarehouseDataSet aFindWIPInventoryPartWarehouseDataSet;
        FindWIPInventoryPartWarehouseDataSetTableAdapters.FindWIPInventoryPartWarehouseTableAdapter aFindWIPInventoryPartWarehouseTableAdapter;

        FindWIPInventoryWarehouseDataSet aFindWIPInventoryWarehouseDataSet;
        FindWIPInventoryWarehouseDataSetTableAdapters.FindWIPInventoryWarehouseTableAdapter aFindWIPInventoryWarehouseTableAdapter;

        FindWIPInventoryTotalDataSet aFindWIPInventoryTotalDataSet;
        FindWIPInventoryTotalDataSetTableAdapters.FindWIPInventoryTotalTableAdapter aFindWIPInventoryTotalTableAdapter;

        ReturnedInventoryDataSet aReturnedInventoryDataSet;
        ReturnedInventoryDataSetTableAdapters.returnedinventoryTableAdapter aReturnedInventoryTableAdapter;

        InsertReturnedInventoryEntryTableAdapters.QueriesTableAdapter aInsertReturnedInventoryTableAdapter;

        FindReturnedInventoryByEmployeeIDDataSet aFindReturnedInventoryByEmployeeIDDataSet;
        FindReturnedInventoryByEmployeeIDDataSetTableAdapters.FindReturnedInventoryByEmployeeIDTableAdapter aFindReturnedInventoryByEmployeeIDTableAdapter;

        VoidReturnInventoryEntryTableAdapters.QueriesTableAdapter aVoidReturnedInventoryTableAdapter;

        FindReturnedInventoryForTodayDataSet aFindReturnedInventoryForTodayDataSet;
        FindReturnedInventoryForTodayDataSetTableAdapters.FindReturnedInventoryForTodayTableAdapter aFindReturnedInventoryForTodayTableAdapter;

        FindReturnedInventoryOverDateRangeDataSet aFindReturnedInventoryOverDateRangeDataSet;
        FindReturnedInventoryOverDateRangeDataSetTableAdapters.FindReturnedInventoryOverDateRangeTableAdapter aFindReturnedInventoryOverDateRangeTableAdapter;

        ProjectMaterialUsedDataSet aProjectMaterialUsedDataSet;
        ProjectMaterialUsedDataSetTableAdapters.projectmaterialusedTableAdapter aProjectMaterialUsedTableAdapter;

        InsertProjectMaterialUsedEntryTableAdapters.QueriesTableAdapter aInsertProjectMaterialUsedTableAdapter;

        FindProjectMaterialUsedForProjectDataSet aFindProjectMaterialUsedForProjectDataSet;
        FindProjectMaterialUsedForProjectDataSetTableAdapters.FindProjectMaterialUsedForProjectTableAdapter aFindProjectMaterialUsedForProjectTableAdapter;

        FindProjectMaterialUsedOverDateRangeDataSet aFindProjectMaterialUsedOverDateRangeDataSet;
        FindProjectMaterialUsedOverDateRangeDataSetTableAdapters.FindProjectMaterialUsedOverDateRangeTableAdapter aFindProjectMaterialUsedOverDateRangeTableAdapter;

        public FindProjectMaterialUsedOverDateRangeDataSet FindProjectMaterialUsedOverDateRange(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindProjectMaterialUsedOverDateRangeDataSet = new FindProjectMaterialUsedOverDateRangeDataSet();
                aFindProjectMaterialUsedOverDateRangeTableAdapter = new FindProjectMaterialUsedOverDateRangeDataSetTableAdapters.FindProjectMaterialUsedOverDateRangeTableAdapter();
                aFindProjectMaterialUsedOverDateRangeTableAdapter.Fill(aFindProjectMaterialUsedOverDateRangeDataSet.FindProjectMaterialUsedOverDateRange, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Find Project Material Used Over Date Range " + Ex.Message);
            }

            return aFindProjectMaterialUsedOverDateRangeDataSet;
        }
        public FindProjectMaterialUsedForProjectDataSet FindProjectMaterialForProject(int intProjectID)
        {
            try
            {
                aFindProjectMaterialUsedForProjectDataSet = new FindProjectMaterialUsedForProjectDataSet();
                aFindProjectMaterialUsedForProjectTableAdapter = new FindProjectMaterialUsedForProjectDataSetTableAdapters.FindProjectMaterialUsedForProjectTableAdapter();
                aFindProjectMaterialUsedForProjectTableAdapter.Fill(aFindProjectMaterialUsedForProjectDataSet.FindProjectMaterialUsedForProject, intProjectID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Find Project Material Used For Project " + Ex.Message);
            }

            return aFindProjectMaterialUsedForProjectDataSet;
        }
        public bool InsertProjectMaterialUsed(DateTime datTransactionDate, int intProjectID, int intPartID, int intWarehouseID, int intQuantity, int intWarehouseEmployeeID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertProjectMaterialUsedTableAdapter = new InsertProjectMaterialUsedEntryTableAdapters.QueriesTableAdapter();
                aInsertProjectMaterialUsedTableAdapter.InsertProjectMaterialUsed(datTransactionDate, intProjectID, intPartID, intWarehouseID, intQuantity, intWarehouseEmployeeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Insert Project Material Used " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public ProjectMaterialUsedDataSet GetProjectMaterialUsedInfo()
        {
            try
            {
                aProjectMaterialUsedDataSet = new ProjectMaterialUsedDataSet();
                aProjectMaterialUsedTableAdapter = new ProjectMaterialUsedDataSetTableAdapters.projectmaterialusedTableAdapter();
                aProjectMaterialUsedTableAdapter.Fill(aProjectMaterialUsedDataSet.projectmaterialused);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Get Project Material Used Info " + Ex.Message);
            }

            return aProjectMaterialUsedDataSet;
        }
        public void UpdateProjectMaterialUsedDB(ProjectMaterialUsedDataSet aProjectMaterialUsedDataSet)
        {
            try
            {
                aProjectMaterialUsedTableAdapter = new ProjectMaterialUsedDataSetTableAdapters.projectmaterialusedTableAdapter();
                aProjectMaterialUsedTableAdapter.Update(aProjectMaterialUsedDataSet.projectmaterialused);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Update Project Material Used DB " + Ex.Message);
            }
        }
        public FindReturnedInventoryOverDateRangeDataSet FindReturnedInventoryOverDateRange(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindReturnedInventoryOverDateRangeDataSet = new FindReturnedInventoryOverDateRangeDataSet();
                aFindReturnedInventoryOverDateRangeTableAdapter = new FindReturnedInventoryOverDateRangeDataSetTableAdapters.FindReturnedInventoryOverDateRangeTableAdapter();
                aFindReturnedInventoryOverDateRangeTableAdapter.Fill(aFindReturnedInventoryOverDateRangeDataSet.FindReturnedInventoryOverDateRange, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Find Returned Inventory OIver Date Range " + Ex.Message);
            }

            return aFindReturnedInventoryOverDateRangeDataSet;
        }
        public FindReturnedInventoryForTodayDataSet FindReturnedInventoryForToday(DateTime datStartDate)
        {
            try
            {
                aFindReturnedInventoryForTodayDataSet = new FindReturnedInventoryForTodayDataSet();
                aFindReturnedInventoryForTodayTableAdapter = new FindReturnedInventoryForTodayDataSetTableAdapters.FindReturnedInventoryForTodayTableAdapter();
                aFindReturnedInventoryForTodayTableAdapter.Fill(aFindReturnedInventoryForTodayDataSet.FindReturnedInventoryForToday, datStartDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Find Returned Inventory For Today " + Ex.Message);
            }

            return aFindReturnedInventoryForTodayDataSet;
        }
        public bool VoidReturnedInventory(int intTransactionID)
        {
            bool blnFatalError = false;

            try
            {
                aVoidReturnedInventoryTableAdapter = new VoidReturnInventoryEntryTableAdapters.QueriesTableAdapter();
                aVoidReturnedInventoryTableAdapter.VoidReturnedInventory(intTransactionID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Void Returned Inventory " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public FindReturnedInventoryByEmployeeIDDataSet FindReturnedInventoryByEmployeeID(int intEmployeeID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindReturnedInventoryByEmployeeIDDataSet = new FindReturnedInventoryByEmployeeIDDataSet();
                aFindReturnedInventoryByEmployeeIDTableAdapter = new FindReturnedInventoryByEmployeeIDDataSetTableAdapters.FindReturnedInventoryByEmployeeIDTableAdapter();
                aFindReturnedInventoryByEmployeeIDTableAdapter.Fill(aFindReturnedInventoryByEmployeeIDDataSet.FindReturnedInventoryByEmployeeID, intEmployeeID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Find Returned Inventory By Employee ID " + Ex.Message);
            }

            return aFindReturnedInventoryByEmployeeIDDataSet;
        }
        public bool InsertReturnInventory(DateTime datTransactionDate, int intPartID, int intWarehouseID, int intQuantity, int intEmployeeID, int intWarehouseEmployeeID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertReturnedInventoryTableAdapter = new InsertReturnedInventoryEntryTableAdapters.QueriesTableAdapter();
                aInsertReturnedInventoryTableAdapter.InsertReturnedInventory(datTransactionDate, intPartID, intWarehouseID, intQuantity, intEmployeeID, intWarehouseEmployeeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Insert Return Inventory " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public ReturnedInventoryDataSet GetReturnedInventoryInfo()
        {
            try
            {
                aReturnedInventoryDataSet = new ReturnedInventoryDataSet();
                aReturnedInventoryTableAdapter = new ReturnedInventoryDataSetTableAdapters.returnedinventoryTableAdapter();
                aReturnedInventoryTableAdapter.Fill(aReturnedInventoryDataSet.returnedinventory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Get Returned Inventory Info " + Ex.Message);
            }

            return aReturnedInventoryDataSet;
        }
        public void UpdateReturnedInventoryDB(ReturnedInventoryDataSet aReturnedInventoryDataSet)
        {
            try
            {
                aReturnedInventoryTableAdapter = new ReturnedInventoryDataSetTableAdapters.returnedinventoryTableAdapter();
                aReturnedInventoryTableAdapter.Update(aReturnedInventoryDataSet.returnedinventory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Update Returned Inventory DB " + Ex.Message);
            }
        }
        public FindWIPInventoryTotalDataSet FindWIPInventoryTotal()
        {
            try
            {
                aFindWIPInventoryTotalDataSet = new FindWIPInventoryTotalDataSet();
                aFindWIPInventoryTotalTableAdapter = new FindWIPInventoryTotalDataSetTableAdapters.FindWIPInventoryTotalTableAdapter();
                aFindWIPInventoryTotalTableAdapter.Fill(aFindWIPInventoryTotalDataSet.FindWIPInventoryTotal);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Find WIP Inventory Total " + Ex.Message);
            }

            return aFindWIPInventoryTotalDataSet;
        }
        public FindWIPInventoryWarehouseDataSet FindWIPInventoryWarehouse(int intWarehouseID)
        {
            try
            {
                aFindWIPInventoryWarehouseDataSet = new FindWIPInventoryWarehouseDataSet();
                aFindWIPInventoryWarehouseTableAdapter = new FindWIPInventoryWarehouseDataSetTableAdapters.FindWIPInventoryWarehouseTableAdapter();
                aFindWIPInventoryWarehouseTableAdapter.Fill(aFindWIPInventoryWarehouseDataSet.FindWIPInventoryWarehouse, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Find WIP Inventory Warehouse " + Ex.Message);
            }

            return aFindWIPInventoryWarehouseDataSet;
        }
        public FindWIPInventoryPartWarehouseDataSet FindWIPInventoryPartWarehouse(int intPartID, int intWarehouseID)
        {
            try
            {
                aFindWIPInventoryPartWarehouseDataSet = new FindWIPInventoryPartWarehouseDataSet();
                aFindWIPInventoryPartWarehouseTableAdapter = new FindWIPInventoryPartWarehouseDataSetTableAdapters.FindWIPInventoryPartWarehouseTableAdapter();
                aFindWIPInventoryPartWarehouseTableAdapter.Fill(aFindWIPInventoryPartWarehouseDataSet.FindWIPInventoryPartWarehouse, intPartID, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Find WIP Inventory Part Warehouse " + Ex.Message);
            }

            return aFindWIPInventoryPartWarehouseDataSet;
        }
        public bool UpdateWIPInventory(int intTransactionID, int intQuantity)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateWIPInventoryTableAdapter = new UpdateWIPInventoryEntryTableAdapters.QueriesTableAdapter();
                aUpdateWIPInventoryTableAdapter.UpdateWIPInventory(intTransactionID, intQuantity);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Update WIP Inventory " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertWIPInventory(int intPartID, int intWarehouseID, int intQuantity)
        {
            bool blnFatalError = false;

            try
            {
                aInsertWIPInventoryTableAdapter = new InsertWIPInventoryEntryTableAdapters.QueriesTableAdapter();
                aInsertWIPInventoryTableAdapter.InsertWIPInventory(intPartID, intWarehouseID, intQuantity);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Insert WIP Inventory " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public WIPInventoryDataSet GetWIPInventoryInfo()
        {
            try
            {
                aWIPInventoryDataSet = new WIPInventoryDataSet();
                aWIPInventoryTableAdapter = new WIPInventoryDataSetTableAdapters.wipinventoryTableAdapter();
                aWIPInventoryTableAdapter.Fill(aWIPInventoryDataSet.wipinventory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Get WIP Inventory Info " + Ex.Message);
            }

            return aWIPInventoryDataSet;
        }
        public void UpdateWIPInventoryDB(WIPInventoryDataSet aWIPInventoryDataSet)
        {
            try
            {
                aWIPInventoryTableAdapter = new WIPInventoryDataSetTableAdapters.wipinventoryTableAdapter();
                aWIPInventoryTableAdapter.Update(aWIPInventoryDataSet.wipinventory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Process Class // Update WIP Inventory DB " + Ex.Message);
            }
        }
    }
}
