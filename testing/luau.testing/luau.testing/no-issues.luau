-- This file should have no linting or syntax errors
local hello: string = 'world'
print(hello)

local values = {1, 4, 2, 6, 7}
local sum = 0
for _, v in pairs(values) do
	sum = sum + v
end

print('Mean: ' .. (sum / #values))
