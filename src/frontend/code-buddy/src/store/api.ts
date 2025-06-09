import { emptySplitApi as api } from "./emptyApi";
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    getApiMainGetData: build.query<
      GetApiMainGetDataApiResponse,
      GetApiMainGetDataApiArg
    >({
      query: () => ({ url: `/api/Main/GetData` }),
    }),
    postApiOrganizations: build.mutation<
      PostApiOrganizationsApiResponse,
      PostApiOrganizationsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Organizations`,
        method: "POST",
        body: queryArg.createOrganizationRequest,
      }),
    }),
  }),
  overrideExisting: false,
});
export { injectedRtkApi as api };
export type GetApiMainGetDataApiResponse = unknown;
export type GetApiMainGetDataApiArg = void;
export type PostApiOrganizationsApiResponse = unknown;
export type PostApiOrganizationsApiArg = {
  createOrganizationRequest: CreateOrganizationRequest;
};
export type CreateOrganizationRequest = {
  name?: string | null;
  displayName?: string | null;
};
export const { useGetApiMainGetDataQuery, usePostApiOrganizationsMutation } =
  injectedRtkApi;
