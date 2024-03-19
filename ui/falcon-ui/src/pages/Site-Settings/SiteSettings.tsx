import EditOutlinedIcon from "@mui/icons-material/EditOutlined";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { Button, Grid, Stack } from "@mui/material";
import Accordion from "@mui/material/Accordion";
import AccordionDetails from "@mui/material/AccordionDetails";
import AccordionSummary from "@mui/material/AccordionSummary";
import Typography from "@mui/material/Typography";
import { useRef, useState } from "react";
import AddNewSetting from "@feature-components/settings/AddNewSetting";
import ThemeConfig from "@feature-components/Theme/ThemeConfig";
import AppLoader from "@ui-components/AppLoader";
import AppModal from "@ui-components/AppModal";
import { TenantSettingsResponse } from "@models/Settings/TenantSettingsResponse";
import {
  useAddNewSettingMutation,
  useGetTenantSettingsQuery,
} from "@services/Settings/SettingService";
export default function SiteSettings() {
  const [expanded, setExpanded] = useState<string | false>(false);
  const { data: tenantSettings, isLoading } = useGetTenantSettingsQuery(null);
  const [showPopup, setShowPopup] = useState<boolean>(false);
  const addNewSettingFormRef = useRef<any>(null);
  const [addNewSetting] = useAddNewSettingMutation();

  const handleChange =
    (panel: string) => (event: React.SyntheticEvent, isExpanded: boolean) => {
      setExpanded(isExpanded ? panel : false);
    };

  const addNewSettingFormSubmit = (data: any, { resetForm }: any) => {
    addNewSetting(data)
      .unwrap()
      .then(() => {
        resetForm();
        setShowPopup(false);
      });
  };

  const handleAddNewSetting = () => {
    addNewSettingFormRef.current.submit();
  };

  return (
    <>
      <Grid container>
        <Grid item md={12}>
          <ThemeConfig />
        </Grid>
        <Grid item md={12}>
          <Stack alignItems="flex-end">
            <Button
              sx={{ width: "fit-content" }}
              onClick={() => setShowPopup(true)}
              variant="contained"
            >
              Add New Setting
            </Button>
          </Stack>
        </Grid>
        <Grid item md={3} xs={12} sm={12}>
          <div>
            {isLoading ? (
              <AppLoader />
            ) : (
              tenantSettings?.response.map((x: TenantSettingsResponse) => {
                return (
                  <Accordion
                    expanded={expanded === x.settingType}
                    onChange={handleChange(x.settingType)}
                  >
                    <AccordionSummary
                      expandIcon={<ExpandMoreIcon />}
                      aria-controls="panel1bh-content"
                      id="panel1bh-header"
                    >
                      <Typography sx={{ width: "33%", flexShrink: 0 }}>
                        {x.settingType}
                      </Typography>
                    </AccordionSummary>
                    <AccordionDetails>
                      <Grid container spacing={1}>
                        <Grid item md={12} sm={12}>
                          <Stack alignItems="flex-end">
                            <Button
                              sx={{ width: "fit-content" }}
                              variant="outlined"
                              startIcon={<EditOutlinedIcon />}
                            >
                              UPDATE THEME
                            </Button>
                          </Stack>
                        </Grid>

                        {x.settings.map((x) => (
                          <Grid item md={12} sm={12}>
                            <Stack>
                              <Typography variant="subtitle2">
                                {x.displayName}
                              </Typography>
                              <Typography variant="body2">{x.value}</Typography>
                            </Stack>
                          </Grid>
                        ))}
                      </Grid>
                    </AccordionDetails>
                  </Accordion>
                );
              })
            )}
          </div>
        </Grid>
      </Grid>
      <AppModal
        show={showPopup}
        modalTitle="Add new setting"
        okButtonText="Add"
        handleOk={handleAddNewSetting}
        handleClose={() => setShowPopup(false)}
      >
        <AddNewSetting
          handleFormSubmit={addNewSettingFormSubmit}
          formReference={addNewSettingFormRef}
        />
      </AppModal>
    </>
  );
}
