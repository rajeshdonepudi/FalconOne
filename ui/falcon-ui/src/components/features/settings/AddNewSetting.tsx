import {
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  Stack,
  TextField,
} from "@mui/material";
import { useFormik } from "formik";
import AddNewSettingValidationScheme from "@/validation-schemes/Site-settings/AddNewSettingValidationScheme";
import { useGetSettingsTypesQuery } from "@services/Settings/SettingService";
import { KeyValuePair } from "@models/Common/KeyValuePair";

const AddNewSetting = (props: any) => {
  const { data: settingTypes } = useGetSettingsTypesQuery(null);

  const formik = useFormik({
    initialValues: {
      name: "",
      displayName: "",
      value: "",
      description: "",
      settingType: 0,
    },
    validationSchema: AddNewSettingValidationScheme,
    onSubmit: props.handleFormSubmit,
    onReset: props.handleFormReset,
  });
  return (
    <Stack direction="row" justifyContent="center">
      <form onSubmit={formik.handleSubmit} ref={props.formReference}>
        <Stack spacing={2}>
          <Stack gap={1} flexDirection="row">
            <TextField
              id="name"
              name="name"
              label="Name"
              variant="outlined"
              value={formik.values.name}
              onChange={formik.handleChange}
              error={formik.touched.name && Boolean(formik.errors.name)}
              helperText={formik.touched.name && formik.errors.name}
            />
            <TextField
              id="displayName"
              name="displayName"
              label="Display Name"
              variant="outlined"
              value={formik.values.displayName}
              onChange={formik.handleChange}
              error={
                formik.touched.displayName && Boolean(formik.errors.displayName)
              }
              helperText={
                formik.touched.displayName && formik.errors.displayName
              }
            />
          </Stack>
          <TextField
            id="value"
            name="value"
            label="Value"
            variant="outlined"
            value={formik.values.value}
            onChange={formik.handleChange}
            error={formik.touched.value && Boolean(formik.errors.value)}
            helperText={formik.touched.value && formik.errors.value}
          />
          <TextField
            id="description"
            name="description"
            label="Description"
            variant="outlined"
            multiline
            rows={4}
            value={formik.values.description}
            onChange={formik.handleChange}
            error={
              formik.touched.description && Boolean(formik.errors.description)
            }
            helperText={formik.touched.description && formik.errors.description}
          />
          <FormControl fullWidth>
            <InputLabel id="settingType">Setting Type</InputLabel>
            <Select
              labelId="settingType"
              id="settingType"
              name="settingType"
              value={formik.values.settingType}
              label="Setting Type"
              onChange={formik.handleChange}
            >
              {settingTypes?.response?.map(
                (s: KeyValuePair<string, number>) => (
                  <MenuItem key={s.key} value={s.value}>
                    {s.key}
                  </MenuItem>
                )
              )}
            </Select>
          </FormControl>
        </Stack>
      </form>
    </Stack>
  );
};

export default AddNewSetting;
