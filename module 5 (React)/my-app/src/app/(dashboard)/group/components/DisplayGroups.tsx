import Button from "@/components/Button";
import {
  openDeleteGroupModal,
  openEditGroupModal,
} from "@/lib/feature/groups/groups.slice";
import { useAppDispatch } from "@/lib/hooks";
import React from "react";

type Props = {
  groups: any[];
};

const DisplayGroups = (props: Props) => {
  const dispatch = useAppDispatch();

  return (
    <div className="w-full">
      <div className="divide-y divide-solid">
        {props.groups.map((group: any, index: number) => {
          return (
            <div key={index} className="py-4 flex gap-2">
              <p className="text-lg mr-auto">{group.name}</p>
              <Button
                label="Edit"
                onClick={() => dispatch(openEditGroupModal(group.name))}
              />
              <Button
                label="Delete"
                onClick={() => dispatch(openDeleteGroupModal(group.name))}
              />
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default DisplayGroups;
