import { RootState } from "@/lib/store";
import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";

interface GroupState {
  input: { name: string };
  selectedGroup: { name: string };
  hideModal: {
    create: boolean;
    edit: boolean;
    delete: boolean;
  };
}

const initialState: GroupState = {
  selectedGroup: {
    name: "",
  },
  hideModal: {
    create: true,
    edit: true,
    delete: true,
  },
  input: {
    name: "",
  },
};

export const groupSlice = createSlice({
  name: "group",
  initialState,
  reducers: {
    closeGroupModal: (state) => ({
      ...state,
      hideModal: {
        create: true,
        edit: true,
        delete: true,
      },
    }),
    openCreateGroupModal: (state) => ({
      ...state,
      input: { name: "" },
      hideModal: {
        create: false,
        edit: true,
        delete: true,
      },
    }),
    openEditGroupModal: (state, action: PayloadAction<string>) => ({
      ...state,
      input: { name: action.payload },
      selectedGroup: { name: action.payload },
      hideModal: {
        create: true,
        edit: false,
        delete: true,
      },
    }),
    openDeleteGroupModal: (state, action: PayloadAction<string>) => ({
      ...state,
      input: { name: action.payload },
      selectedGroup: { name: action.payload },
      hideModal: {
        create: true,
        edit: true,
        delete: false,
      },
    }),
    groupModalInput: (state, action: PayloadAction<string>) => ({
      ...state,
      input: { name: action.payload },
    }),
  },
});

export const {
  closeGroupModal,
  openCreateGroupModal,
  openEditGroupModal,
  openDeleteGroupModal,
  groupModalInput,
} = groupSlice.actions;

export const selectGroupModalState = (state: RootState) =>
  state.group.hideModal;

export const selectedGroup = (state: RootState) => state.group.selectedGroup;

export const selectGroupModalInput = (state: RootState) => state.group.input;

export default groupSlice.reducer;
