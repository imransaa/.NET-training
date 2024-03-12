import { configureStore } from "@reduxjs/toolkit";
import groupReducer from "./feature/groups/groups.slice";

const makeStore = () =>
  configureStore({
    reducer: {
      group: groupReducer,
    },
  });

export default makeStore;

export type AppStore = ReturnType<typeof makeStore>;

export type RootState = ReturnType<AppStore["getState"]>;

export type AppDispatch = AppStore["dispatch"];
