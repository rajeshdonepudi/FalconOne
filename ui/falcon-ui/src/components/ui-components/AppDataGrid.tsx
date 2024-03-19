import {
  DataGrid,
  GridCallbackDetails,
  GridColDef,
  GridPaginationModel,
  GridRowsProp,
} from "@mui/x-data-grid";
import AppConstants from "../../constants/constants";

const AppDataGrid = (props: {
  records: GridRowsProp<any>;
  columns: GridColDef[];
  totalRecords: number;
  isFetching: boolean;
  paginationState: GridPaginationModel;
  columnsToHide: {};
  setPaginationState: (
    model: GridPaginationModel,
    details: GridCallbackDetails<any>
  ) => void;
  setRowId: (row: any) => string;
  disableRowSelectionOnClick?: boolean;
}) => {
  return (
    <DataGrid
      initialState={{
        columns: {
          columnVisibilityModel: props?.columnsToHide,
        },
      }}
      rows={props?.records ?? []}
      columns={props?.columns ?? []}
      rowCount={props?.totalRecords ?? 0}
      loading={props?.isFetching ?? false}
      paginationModel={props?.paginationState}
      paginationMode="server"
      onPaginationModelChange={props?.setPaginationState}
      pageSizeOptions={AppConstants.paging.pageSizeOptions}
      checkboxSelection
      getRowId={props?.setRowId}
      disableRowSelectionOnClick
    />
  );
};

export default AppDataGrid;
