import { configureStore } from "@reduxjs/toolkit";
import groupReducer from "./feature/groups/groups.slice";
import documentReducer from "./feature/documents/documents.slice";

const makeStore = () =>
  configureStore({
    reducer: {
      group: groupReducer,
      document: documentReducer,
    },
  });

export default makeStore;

export type AppStore = ReturnType<typeof makeStore>;

export type RootState = ReturnType<AppStore["getState"]>;

export type AppDispatch = AppStore["dispatch"];
