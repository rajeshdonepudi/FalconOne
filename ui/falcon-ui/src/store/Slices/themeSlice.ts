import { createSlice } from "@reduxjs/toolkit";

const themeSlice = createSlice({
  name: "theme",
  initialState: {
    siteTheme: {
      primary: undefined,
      secondary: undefined,
      theme: undefined,
    },
  },
  reducers: {
    updateTheme: (state, action) => {
      state.siteTheme = action.payload;
    },
  },
});

export const { updateTheme } = themeSlice.actions;
export default themeSlice.reducer;
