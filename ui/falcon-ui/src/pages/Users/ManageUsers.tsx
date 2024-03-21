import { useFormik } from "formik";
import { lazy, useMemo, useRef, useState } from "react";
import { useTranslation } from "react-i18next";
const ArrowForwardIcon = lazy(() => import("@mui/icons-material/ArrowForward"));
const DeleteOutlineOutlinedIcon = lazy(
  () => import("@mui/icons-material/DeleteOutlineOutlined")
);
const EditOutlinedIcon = lazy(() => import("@mui/icons-material/EditOutlined"));
import AppCard from "@ui-components/AppCard";
import AppLazyLoader from "@ui-components/AppLazyLoader";
import AppModal from "@ui-components/AppModal";
import { UserActions } from "@/enumerations/Users/user-actions.enum";
import { AppModalState } from "@models/Common/ModalState";
import {
  useDeleteUserMutation,
  useGetAllUsersQuery,
  useGetUserManagementDashboardInfoQuery,
  useGetUsersCreatedByYearQuery,
  useUpsertUserMutation,
} from "@services/User/UserManagementService";
import UpsertUserForm from "@/components/features/Users/UpsertUserForm";
import {
  GridColDef,
  GridRenderCellParams,
  GridValueGetterParams,
} from "@mui/x-data-grid";
import { IconButton, Tooltip } from "@mui/material";
import { UpsertUserModel } from "@/models/Users/UserModel";
import AppDataGrid from "@/components/ui-components/AppDataGrid";
import UpsertUserValidationScheme from "@/validation-schemes/Users/UpsertUserValidationScheme";
import { toast } from "react-toastify";
import {
  CartesianGrid,
  LineChart,
  XAxis,
  YAxis,
  Tooltip as CTooltip,
  Legend,
  Line,
  PieChart,
  Pie,
  ResponsiveContainer,
  BarChart,
  Bar,
  Rectangle,
  Label,
  Cell,
} from "recharts";

const PermIdentityOutlinedIcon = lazy(
  () => import("@mui/icons-material/PermIdentityOutlined")
);
const PersonOffOutlinedIcon = lazy(
  () => import("@mui/icons-material/PersonOffOutlined")
);
const VerifiedUserOutlinedIcon = lazy(
  () => import("@mui/icons-material/VerifiedUserOutlined")
);
const Button = lazy(() => import("@mui/material/Button"));
const Grid = lazy(() => import("@mui/material/Grid"));
const Stack = lazy(() => import("@mui/material/Stack"));
const Typography = lazy(() => import("@mui/material/Typography"));
const ManageUsers = () => {
  /****
   * Hook's
   */
  const { t: commonLocale } = useTranslation("common");
  const formRef = useRef<HTMLFormElement>(null);

  /**
   * Component states
   */
  const [pageActionsState, setPageActionsState] = useState<AppModalState>({
    visible: false,
    title: undefined,
    actionId: 0,
    data: undefined,
    okButtonText: undefined,
  });

  const [paginationModel, setPaginationModel] = useState({
    page: 0,
    pageSize: 5,
  });

  /****
   * Queries
   */
  const { data: dashboardInfo } = useGetUserManagementDashboardInfoQuery(null);
  const { data: usersCreated } = useGetUsersCreatedByYearQuery(null);
  const { data, isFetching } = useGetAllUsersQuery(paginationModel);

  const usersData = useMemo(() => {
    return data?.data.items ?? [];
  }, [data?.data]);

  /***
   * Mutations
   */
  const [upsertUserMutation] = useUpsertUserMutation();
  const [deleteUserMutation] = useDeleteUserMutation();

  /***
   * Event handlers
   */
  const onClickAddUser = () => {
    setPageActionsState({
      actionId: UserActions.ADD_USER,
      title: `${commonLocale("add")} ${commonLocale("user")}`,
      data: {},
      visible: true,
      okButtonText: commonLocale("add"),
    });
  };

  const handleModalClose = () => {
    formik.resetForm();
    setPageActionsState((prev: AppModalState) => {
      return {
        ...prev,
        visible: false,
        data: {},
        title: undefined,
        okButtonText: undefined,
        actionId: 0,
      };
    });
  };

  const showMessage = () => {
    switch (pageActionsState.actionId) {
      case UserActions.ADD_USER:
        toast("User created successfully.");
        break;
      case UserActions.EDIT_USER:
        toast("User updated successfully.");
        break;
      case UserActions.DELETE_USER:
        toast("User deleted successfully");
        break;
    }
  };

  const handleSubmit = (values: UpsertUserModel) => {
    console.log("form values", values);
    upsertUserMutation(values)
      .unwrap()
      .then(() => {
        showMessage();
      })
      .then(() => {
        handleModalClose();
      });
  };

  const formik = useFormik<UpsertUserModel>({
    initialValues: {
      firstName: "",
      lastName: "",
      email: "",
      phone: "",
      password: "",
      confirmPassword: "",
      emailConfirmed: false,
      id: "",
      phoneNumberConfirmed: false,
      twoFactorEnabled: false,
      lockoutEnabled: false,
    },
    validationSchema: UpsertUserValidationScheme(pageActionsState.actionId),
    onSubmit: handleSubmit,
  });

  const handleOk = () => {
    switch (pageActionsState.actionId) {
      case UserActions.ADD_USER:
      case UserActions.EDIT_USER:
        formik.submitForm();
        break;
      case UserActions.DELETE_USER:
        deleteUserMutation(pageActionsState.data.resourceAlias)
          .unwrap()
          .then(() => {
            showMessage();
          })
          .then(() => {
            handleModalClose();
          });
        break;
    }
  };

  const onEditUser = (data: UpsertUserModel) => {
    formik.setValues(data);
    setPageActionsState({
      actionId: UserActions.EDIT_USER,
      title: `${commonLocale("update")} ${commonLocale("user")}`,
      data: data,
      visible: true,
      okButtonText: commonLocale("update"),
    });
  };

  const onDeleteUser = (resourceAlias: string) => {
    setPageActionsState({
      actionId: UserActions.DELETE_USER,
      title: `${commonLocale("delete")} ${commonLocale("user")}`,
      data: { resourceAlias },
      visible: true,
      okButtonText: commonLocale("delete"),
    });
  };

  const columns = useMemo(() => {
    const columns: GridColDef[] = [
      {
        field: "fullName",
        flex: 1,
        headerName: "Full name",
        description: "This column has a value getter and is not sortable.",
        sortable: false,
        valueGetter: (params: GridValueGetterParams) =>
          `${params.row.firstName || ""} ${params.row.lastName || ""}`,
      },
      {
        field: "email",
        headerName: commonLocale("email"),
        type: "number",
        editable: false,
        flex: 1,
      },
      {
        field: "emailConfirmed",
        headerName: `${commonLocale("email")} ${commonLocale("confirmed")}`,
        type: "boolean",
        editable: false,
        flex: 1,
      },
      {
        field: "phone",
        headerName: "Phone",
        flex: 1,
      },
      {
        field: "",
        headerName: "Actions",
        sortable: false,
        flex: 1,
        renderCell: (params: GridRenderCellParams<any>) => {
          return (
            <Stack justifyContent="start" flexDirection="row" gap={1}>
              <Tooltip title="View more">
                <IconButton aria-label="Example">
                  <ArrowForwardIcon sx={{ color: "darkgreen" }} />
                </IconButton>
              </Tooltip>
              <Tooltip title="Edit user">
                <IconButton
                  onClick={() => onEditUser(params.row)}
                  aria-label="Example"
                >
                  <EditOutlinedIcon sx={{ color: "darkblue" }} />
                </IconButton>
              </Tooltip>
              <Tooltip title="Delete user">
                <IconButton
                  onClick={() => onDeleteUser(params.row.resourceAlias)}
                  aria-label="Example"
                >
                  <DeleteOutlineOutlinedIcon sx={{ color: "darkred" }} />
                </IconButton>
              </Tooltip>
            </Stack>
          );
        },
      },
    ];
    return columns;
  }, []);

  const getActionView = (actionId: number) => {
    switch (actionId) {
      case UserActions.DELETE_USER:
        return (
          <Typography variant="h6">
            {commonLocale("delete")} {commonLocale("user")}
          </Typography>
        );
      case UserActions.ADD_USER:
      case UserActions.EDIT_USER:
        return <UpsertUserForm formRef={formRef} formik={formik} />;
    }
  };

  const COLORS = [
    "#008DDA",
    "#41C9E2",
    "#ACE2E1",
    "#F7EEDD",
    "#007F73",
    "#4CCD99",
    "#FFC700",
    "#FFF455",
    "#FF407D",
    "#FFCAD4",
    "#40679E",
    "#1B3C73",
    "#B1B2FF",
    "#AAC4FF",
    "#6096B4",
  ];

  const getRandomColor = () => {
    let num = Math.floor(Math.random() * COLORS.length);
    return COLORS[num];
  };

  return (
    <>
      <AppLazyLoader>
        <Grid container spacing={0.8}>
          <Grid item md={12} sm={12} xs={12}>
            <Stack
              direction="row"
              justifyContent="space-between"
              alignItems="center"
              spacing={2}
            >
              <Typography variant="h6" gutterBottom>
                Manage Users
              </Typography>
              <Stack alignItems="flex-end">
                <Button
                  onClick={onClickAddUser}
                  variant="contained"
                  sx={{ width: "fit-content" }}
                >
                  {`${commonLocale("add")} ${commonLocale("user")}`}
                </Button>
              </Stack>
            </Stack>
          </Grid>
          <Grid item md={12}>
            <Grid container spacing={0.8}>
              <Grid item md={3} xs={12}>
                <AppCard>
                  <Stack>
                    <Stack direction="row" alignItems="center">
                      <PermIdentityOutlinedIcon fontSize="small" />
                      <Typography variant="subtitle2">{`${commonLocale(
                        "total"
                      )} ${commonLocale("users")}`}</Typography>
                    </Stack>
                    <Typography color="darkgreen" variant="h4">
                      {dashboardInfo?.data?.totalUsers}
                    </Typography>
                  </Stack>
                </AppCard>
              </Grid>
              <Grid item md={3} xs={12}>
                <AppCard>
                  <Stack>
                    <Stack direction="row" alignItems="center">
                      <PermIdentityOutlinedIcon fontSize="small" />
                      <Typography variant="subtitle2">{`${commonLocale(
                        "active"
                      )} ${commonLocale("users")}`}</Typography>
                    </Stack>
                    <Typography color="darkgreen" variant="h4">
                      {dashboardInfo?.data?.activeUsers}
                    </Typography>
                  </Stack>
                </AppCard>
              </Grid>
              <Grid item md={3} xs={12}>
                <AppCard>
                  <Stack>
                    <Stack direction="row" alignItems="center">
                      <PersonOffOutlinedIcon fontSize="small" />
                      <Typography variant="subtitle2">
                        {`${commonLocale("deactivated")} ${commonLocale(
                          "users"
                        )}`}
                      </Typography>
                    </Stack>
                    <Typography color="darkred" variant="h4">
                      {dashboardInfo?.data?.deactivatedUsers}
                    </Typography>
                  </Stack>
                </AppCard>
              </Grid>
              <Grid item md={3} xs={12}>
                <AppCard>
                  <Stack>
                    <Stack direction="row" alignItems="center">
                      <VerifiedUserOutlinedIcon fontSize="small" />
                      <Typography variant="subtitle2">{`${commonLocale(
                        "verified"
                      )} ${commonLocale("users")}`}</Typography>
                    </Stack>
                    <Typography color="dodgerblue" variant="h4">
                      {dashboardInfo?.data?.verifiedUsers}
                    </Typography>
                  </Stack>
                </AppCard>
              </Grid>
              <Grid item md={3} xs={12}>
                <AppCard>
                  <Stack>
                    <Stack direction="row" alignItems="center">
                      <VerifiedUserOutlinedIcon fontSize="small" />
                      <Typography variant="subtitle2">{`${commonLocale(
                        "unverified"
                      )} ${commonLocale("users")}`}</Typography>
                    </Stack>
                    <Typography color="dodgerblue" variant="h4">
                      {dashboardInfo?.data?.unVerifiedUsers}
                    </Typography>
                  </Stack>
                </AppCard>
              </Grid>
              <Grid item md={3} xs={12}>
                <AppCard>
                  <Stack>
                    <Stack direction="row" alignItems="center">
                      <PersonOffOutlinedIcon fontSize="small" />
                      <Typography variant="subtitle2">
                        {`${commonLocale("locked")} ${commonLocale("users")}`}
                      </Typography>
                    </Stack>
                    <Typography color="grey" variant="h4">
                      {dashboardInfo?.data?.lockedUsers}
                    </Typography>
                  </Stack>
                </AppCard>
              </Grid>
              <Grid item md={6}>
                <AppCard>
                  <div style={{ width: "100%", height: 250 }}>
                    <ResponsiveContainer width="100%" height="100%">
                      <BarChart
                        width={500}
                        height={300}
                        data={usersCreated?.data as any}
                        margin={{
                          top: 5,
                          right: 30,
                          left: 20,
                          bottom: 5,
                        }}
                      >
                        <CartesianGrid strokeDasharray="3 3" />
                        <XAxis name="Year" dataKey="year" />
                        <YAxis
                          label={{
                            value: "Total Users Created",
                            angle: -90,
                            position: "insideBottomLeft",
                          }}
                        />
                        <CTooltip />
                        <Legend />
                        <Bar name="Year" dataKey="totalUsers" fill="#8884d8">
                          {COLORS.map((entry, index) => (
                            <Cell
                              key={`cell-${index}`}
                              fill={COLORS[index % COLORS.length]}
                            />
                          ))}
                        </Bar>
                      </BarChart>
                    </ResponsiveContainer>
                  </div>
                </AppCard>
              </Grid>
              <Grid item md={12}>
                <Grid container spacing={0.8}>
                  <Grid item md={6} xs={12}>
                    <AppCard>
                      <div style={{ width: "100%", height: 250 }}>
                        <ResponsiveContainer width="100%" height="100%">
                          <LineChart data={usersCreated?.data as any}>
                            <CartesianGrid strokeDasharray="3 3" />
                            <XAxis
                              name="Year"
                              dataKey="year"
                              // padding={{ left: 30, right: 30 }}
                            />
                            <YAxis
                              label={{
                                value: "Total Users Created",
                                angle: -90,
                                position: "insideBottomLeft",
                              }}
                            />
                            <CTooltip />
                            <Legend />
                            <Line
                              name="Year"
                              type="monotone"
                              dataKey="totalUsers"
                              stroke={"#00ADB5"}
                              activeDot={{ r: 8 }}
                            />
                          </LineChart>
                        </ResponsiveContainer>
                      </div>
                    </AppCard>
                  </Grid>
                  <Grid item md={6} xs={12}>
                    <AppCard>
                      <div style={{ width: "100%", height: 250 }}>
                        <ResponsiveContainer width="100%" height="100%">
                          <PieChart width={400} height={400}>
                            <Pie
                              nameKey="year"
                              dataKey="totalUsers"
                              isAnimationActive={false}
                              data={usersCreated?.data as any}
                              cx="50%"
                              cy="50%"
                              outerRadius={80}
                              fill="#008DDA"
                              label
                            >
                              {COLORS.map((entry, index) => (
                                <Cell
                                  key={`cell-${index}`}
                                  fill={COLORS[index % COLORS.length]}
                                />
                              ))}
                            </Pie>
                            <CTooltip />
                          </PieChart>
                        </ResponsiveContainer>
                      </div>
                    </AppCard>
                  </Grid>
                </Grid>
              </Grid>
            </Grid>
          </Grid>
          <Grid item md={12} xs={12}>
            <AppCard>
              <AppDataGrid
                columnsToHide={{
                  id: false,
                }}
                records={usersData}
                columns={columns}
                totalRecords={data?.data?.totalItems ?? 0}
                isFetching={isFetching}
                paginationState={paginationModel}
                setPaginationState={setPaginationModel}
                setRowId={(row) => row.resourceAlias}
                disableRowSelectionOnClick={true}
              />
            </AppCard>
          </Grid>
        </Grid>
        <AppModal
          modalTitle={pageActionsState.title}
          show={pageActionsState.visible}
          okButtonText={pageActionsState.okButtonText}
          handleOk={handleOk}
          handleClose={handleModalClose}
        >
          <AppLazyLoader>
            {getActionView(pageActionsState.actionId)}
          </AppLazyLoader>
        </AppModal>
      </AppLazyLoader>
    </>
  );
};

export default ManageUsers;
