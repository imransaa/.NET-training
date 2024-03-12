import { RootState } from "@/lib/store";
import { PayloadAction, createSlice } from "@reduxjs/toolkit";

interface DocumentState {
  hideModal: { create: boolean; edit: boolean; delete: boolean };
  input: { name: string; type: string };
}

const initialState: DocumentState = {
  hideModal: {
    create: true,
    edit: true,
    delete: true,
  },
  input: {
    name: "",
    type: "",
  },
};

export const documentSlice = createSlice({
  name: "Document",
  initialState,
  reducers: {
    closeDocumentModal: (state) => ({
      ...state,
      hideModal: {
        create: true,
        edit: true,
        delete: true,
      },
    }),
    openCreateDocumentModal: (state) => ({
      ...state,
      input: {
        name: "",
        type: "",
      },
      hideModal: {
        create: false,
        edit: true,
        delete: true,
      },
    }),
    openEditDocumentModal: (
      state,
      action: PayloadAction<{ name: string; type: string }>
    ) => ({
      ...state,
      input: action.payload,
      hideModal: {
        create: true,
        edit: false,
        delete: true,
      },
    }),
    openDeleteDocumentModal: (
      state,
      action: PayloadAction<{ name: string; type: string }>
    ) => ({
      ...state,
      input: action.payload,
      hideModal: {
        create: true,
        edit: true,
        delete: false,
      },
    }),
    documentModalInputChange: (
      state,
      action: PayloadAction<{ key: string; value: string }>
    ) => ({
      ...state,
      input: {
        ...state.input,
        [action.payload.key]: action.payload.value,
      },
    }),
  },
});

export const {
  closeDocumentModal,
  openCreateDocumentModal,
  openEditDocumentModal,
  openDeleteDocumentModal,
  documentModalInputChange,
} = documentSlice.actions;

export const selectDocumentModalState = (state: RootState) =>
  state.document.hideModal;

export const selectDocumentModalInput = (state: RootState) =>
  state.document.input;

export default documentSlice.reducer;
